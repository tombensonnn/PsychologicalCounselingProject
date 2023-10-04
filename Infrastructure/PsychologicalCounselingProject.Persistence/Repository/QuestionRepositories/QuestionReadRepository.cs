using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;
using PsychologicalCounselingProject.Domain.Entities;
using PsychologicalCounselingProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Persistence.Repository.QuestionRepositories
{
    public class QuestionReadRepository : ReadRepository<Question>, IQuestionReadRepository
    {
        public QuestionReadRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
