using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Question.DeleteQuestion
{
    public class DeleteQuestionCommandRequest : IRequest<DeleteQuestionCommandResponse>
    {
        public string Id { get; set; }
    }
}
