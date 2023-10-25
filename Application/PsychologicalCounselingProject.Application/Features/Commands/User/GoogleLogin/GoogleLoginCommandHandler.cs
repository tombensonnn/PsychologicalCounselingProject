using MediatR;
using PsychologicalCounselingProject.Application.Abstraction.Services;
using PsychologicalCounselingProject.Application.DTOs.Security;

namespace PsychologicalCounselingProject.Application.Features.Commands.User.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
           Token token = await _authService.GoogleLoginAsync(request.IdToken, 60 * 60 * 24);

            return new()
            {
                Token = token,
            };
        }
    }
}
