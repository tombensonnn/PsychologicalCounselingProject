using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Answer.DeleteAnswer
{
    public class DeleteAnswerCommandRequest : IRequest<DeleteAnswerCommandResponse>
    {
        public string AnswerId { get; set; }
    }
}
