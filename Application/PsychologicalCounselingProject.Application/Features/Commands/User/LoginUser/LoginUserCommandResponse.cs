using PsychologicalCounselingProject.Application.DTOs.Security;

namespace PsychologicalCounselingProject.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandResponse
    {
        public Token AccessToken { get; set; }
        public string Message { get; set; }
    }
}
