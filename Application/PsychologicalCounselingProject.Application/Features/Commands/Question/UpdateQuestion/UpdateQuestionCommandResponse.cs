using PsychologicalCounselingProject.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Question.UpdateQuestion
{
    public class UpdateQuestionCommandResponse
    {
        public Domain.Entities.Question Question { get; set; }
    }
}
