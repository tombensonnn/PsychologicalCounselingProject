﻿using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PsychologicalCounselingProject.Application.Abstraction.Security;
using PsychologicalCounselingProject.Application.Abstraction.Services;
using PsychologicalCounselingProject.Application.DTOs.Security;
using PsychologicalCounselingProject.Domain.Entities.Identity;

namespace PsychologicalCounselingProject.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
        }

        async Task<Token> CreateUserExternalAsync(AppUser? user, string email, string name, UserLoginInfo info, int accessTokenLifeTime)
        {
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = email,
                        Name = name
                    };
                    await _userManager.CreateAsync(user);
                }
            }

            if (user != null)
            {
                await _userManager.AddLoginAsync(user, info);

                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                return token;
            }
            throw new Exception("Invalid external authentication.");
        }

        public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifetime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["Authentication:Google:ClientId"] }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            var info = new UserLoginInfo("GOOGLE", idToken, "GOOGLE");

            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            return await CreateUserExternalAsync(user, payload.Email, payload.Name, info, accessTokenLifetime);
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifetime)
        {
            AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            }

            if (user == null)
            {
                throw new Exception("Please control your credentials...");
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifetime);

                return token;
            }
            else
                return null;
        }

        public Task<Token> FacebookLoginAsync(string accessToken, int accessTokenLifetime)
        {
            throw new NotImplementedException();
        }
    }
}
