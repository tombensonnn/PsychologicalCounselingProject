using PsychologicalCounselingProject.Application.Repositories.AnswerRepositories;
using PsychologicalCounselingProject.Domain.Entities;
using PsychologicalCounselingProject.Persistence.Context;

namespace PsychologicalCounselingProject.Persistence.Repository.AnswerRepositories
{
    public class AnswerReadRepository : ReadRepository<Answer>, IAnswerReadRepository
    {
        public AnswerReadRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
