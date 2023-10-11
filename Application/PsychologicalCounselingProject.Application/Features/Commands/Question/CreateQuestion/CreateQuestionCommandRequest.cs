using MediatR;

namespace PsychologicalCounselingProject.Application.Features.Commands.Question.CreateQuestion
{
    public class CreateQuestionCommandRequest : IRequest<CreateQuestionCommandResponse>
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public string ModuleId { get; set; }
    }
}
