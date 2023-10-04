using MediatR;
using PsychologicalCounselingProject.Domain.Entities;

namespace PsychologicalCounselingProject.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandRequest : IRequest<CreateModuleCommandResponse>
    {
        public string Name { get; set; }
        public int QuestionSize { get; set; }
        public string ConsultantId { get; set; }
    }
}
