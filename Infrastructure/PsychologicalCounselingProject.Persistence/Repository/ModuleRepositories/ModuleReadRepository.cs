using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;
using PsychologicalCounselingProject.Domain.Entities;
using PsychologicalCounselingProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Persistence.Repository.ModuleRepositories
{
    public class ModuleReadRepository : ReadRepository<Module>, IModuleReadRepository
    {
        public ModuleReadRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
