using PsychologicalCounselingProject.Domain.Entities.Common;

namespace PsychologicalCounselingProject.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public Module Module { get; set; }
    }
}
