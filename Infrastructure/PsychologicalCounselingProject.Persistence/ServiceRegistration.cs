using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;
using PsychologicalCounselingProject.Application.Repositories.UserRepositories;
using PsychologicalCounselingProject.Persistence.Configurations;
using PsychologicalCounselingProject.Persistence.Context;
using PsychologicalCounselingProject.Persistence.Repository.ModuleRepositories;
using PsychologicalCounselingProject.Persistence.Repository.QuestionRepositories;
using PsychologicalCounselingProject.Persistence.Repository.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(DbConfiguration.ConnectionString));

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IModuleReadRepository, ModuleReadRepository>();
            services.AddScoped<IModuleWriteRepository, ModuleWriteRepository>();
            services.AddScoped<IQuestionReadRepository, QuestionReadRepository>();
            services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();
        }
    }
}
