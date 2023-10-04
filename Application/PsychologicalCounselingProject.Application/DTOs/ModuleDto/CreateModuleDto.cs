using PsychologicalCounselingProject.Domain.Entities;

namespace PsychologicalCounselingProject.Application.DTOs.ModuleDto
{
    public class CreateModuleDto
    {
        public string Name { get; set; }
        public int QuestionSize { get; set; }
        public User Consultant { get; set; }
    }
}
