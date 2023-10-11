using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Question.UpdateQuestion
{
    public class UpdateQuestionCommandRequest : IRequest<UpdateQuestionCommandResponse>
    {
        public string QuestionId { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
    }
}
