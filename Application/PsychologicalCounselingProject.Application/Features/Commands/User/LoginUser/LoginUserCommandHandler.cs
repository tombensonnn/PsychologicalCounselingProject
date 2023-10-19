using MediatR;
using Microsoft.AspNetCore.Identity;
using PsychologicalCounselingProject.Application.Abstraction.Security;
using PsychologicalCounselingProject.Application.DTOs.Security;
using PsychologicalCounselingProject.Domain.Entities.Identity;

namespace PsychologicalCounselingProject.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {

        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

            if(user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            }

            if(user == null)
            {
                throw new Exception("Please control your credentials...");
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(1);

                return new()
                {
                    AccessToken = token,
                    Message = "Login successfully"
                };
            }
            else
                return new()
                {
                    AccessToken = null,
                    Message = "Something went wrong"
                };
        }
    }
}
