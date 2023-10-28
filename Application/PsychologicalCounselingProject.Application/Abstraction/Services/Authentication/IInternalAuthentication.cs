using PsychologicalCounselingProject.Application.DTOs.Security;

namespace PsychologicalCounselingProject.Application.Abstraction.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifetime);
    }
}
