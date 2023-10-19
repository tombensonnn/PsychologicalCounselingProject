using Microsoft.Extensions.DependencyInjection;
using PsychologicalCounselingProject.Application.Abstraction.Security;
using PsychologicalCounselingProject.Infrastructure.Security;

namespace PsychologicalCounselingProject.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITokenHandler, TokenHandler>();
        }
    }
}
