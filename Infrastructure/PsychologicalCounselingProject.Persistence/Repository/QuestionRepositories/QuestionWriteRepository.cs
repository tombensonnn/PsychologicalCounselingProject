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
    public class QuestionWriteRepository : WriteRepository<Question>, IQuestionWriteRepository
    {
        public QuestionWriteRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
