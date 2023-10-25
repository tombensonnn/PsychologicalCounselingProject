using PsychologicalCounselingProject.Application.Abstraction.Services.Authentication;

namespace PsychologicalCounselingProject.Application.Abstraction.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    {
    }
}
