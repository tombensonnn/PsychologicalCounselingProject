using MediatR;
using Microsoft.AspNetCore.Identity;
using PsychologicalCounselingProject.Application.Abstraction.Security;
using PsychologicalCounselingProject.Application.Abstraction.Services;
using PsychologicalCounselingProject.Application.DTOs.Security;
using PsychologicalCounselingProject.Domain.Entities.Identity;

namespace PsychologicalCounselingProject.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {

        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 60 * 60 * 24);

            return new()
            {
                AccessToken = token,
                Message = "Login successfully"
            };
        }
    }
}
