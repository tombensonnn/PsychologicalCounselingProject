using PsychologicalCounselingProject.Domain.Entities;
using PsychologicalCounselingProject.Domain.Entities.Identity;

namespace PsychologicalCounselingProject.Application.DTOs.ModuleDto
{
    public class CreateModuleDto
    {
        public string Name { get; set; }
        public int QuestionSize { get; set; }
        public AppUser Consultant { get; set; }
    }
}
