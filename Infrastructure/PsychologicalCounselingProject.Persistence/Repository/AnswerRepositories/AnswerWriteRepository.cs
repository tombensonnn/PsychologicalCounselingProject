using PsychologicalCounselingProject.Application.Repositories.AnswerRepositories;
using PsychologicalCounselingProject.Domain.Entities;
using PsychologicalCounselingProject.Persistence.Context;

namespace PsychologicalCounselingProject.Persistence.Repository.AnswerRepositories
{
    public class AnswerWriteRepository : WriteRepository<Answer>, IAnswerWriteRepository
    {
        public AnswerWriteRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
