using MediatR;

namespace PsychologicalCounselingProject.Application.Features.Commands.Answer.UpdateAnswer
{
    public class UpdateAnswerCommandRequest : IRequest<UpdateAnswerCommandResponse>
    {
        public string AnswerId { get; set; }
        public string Content { get; set; }
    }
}
