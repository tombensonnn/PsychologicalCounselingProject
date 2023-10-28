using MediatR;
using PsychologicalCounselingProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Answer.CreateAnswer
{
    public class CreateAnswerCommandRequest : IRequest<CreateAnswerCommandResponse>
    {
        public string QuestionId { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
