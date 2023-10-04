using PsychologicalCounselingProject.Domain.Entities.Common;

namespace PsychologicalCounselingProject.Domain.Entities
{
    public class Module : BaseEntity
    {
        public string Name { get; set; }
        public int QuestionSize { get; set; }
        public ICollection<Question> Questions { get; set; }
        public User Consultant { get; set; }
    }
}
