using PsychologicalCounselingProject.Domain.Entities.Common;

namespace PsychologicalCounselingProject.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UniversityNumber { get; set; }
        public string University { get; set; }
    }
}
