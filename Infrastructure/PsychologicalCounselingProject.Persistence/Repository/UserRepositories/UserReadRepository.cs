using PsychologicalCounselingProject.Application.Repositories.UserRepositories;
using PsychologicalCounselingProject.Domain.Entities;
using PsychologicalCounselingProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Persistence.Repository.UserRepositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ApplicationDbContext context) : base(context)
        {   
        }
    }
}
