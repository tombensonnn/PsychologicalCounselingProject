using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;
using PsychologicalCounselingProject.Domain.Entities.Identity;
using PsychologicalCounselingProject.Persistence.Configurations;
using PsychologicalCounselingProject.Persistence.Context;
using PsychologicalCounselingProject.Persistence.Repository.ModuleRepositories;
using PsychologicalCounselingProject.Persistence.Repository.QuestionRepositories;

namespace PsychologicalCounselingProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(DbConfiguration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IModuleReadRepository, ModuleReadRepository>();
            services.AddScoped<IModuleWriteRepository, ModuleWriteRepository>();
            services.AddScoped<IQuestionReadRepository, QuestionReadRepository>();
            services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();
        }
    }
}
