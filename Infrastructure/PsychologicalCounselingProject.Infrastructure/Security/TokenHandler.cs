using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PsychologicalCounselingProject.Application.Abstraction.Security;
using PsychologicalCounselingProject.Application.DTOs.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Infrastructure.Security
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(int seconds)
        {
            Token token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddSeconds(seconds);

            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                notBefore: DateTime.UtcNow,
                expires: token.Expiration,
                signingCredentials: credentials
                );

            JwtSecurityTokenHandler securityTokenHandler = new();
            token.AccessToken = securityTokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
