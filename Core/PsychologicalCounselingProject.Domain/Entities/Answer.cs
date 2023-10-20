using PsychologicalCounselingProject.Domain.Entities.Common;
using PsychologicalCounselingProject.Domain.Entities.Identity;

namespace PsychologicalCounselingProject.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public Question Question { get; set; }
        public string Content { get; set; }
        public AppUser User { get; set; }
    }
}
