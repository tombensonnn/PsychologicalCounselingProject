using PsychologicalCounselingProject.Application.DTOs.Security;

namespace PsychologicalCounselingProject.Application.Abstraction.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifetime);
        Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifetime);
    }
}
