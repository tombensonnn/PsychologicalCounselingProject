using PsychologicalCounselingProject.Domain.Entities.Common;

namespace PsychologicalCounselingProject.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public Module Module { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}
