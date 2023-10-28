using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAnswersByQuestion
{
    public class GetAnswersByQuestionQueryRequest : IRequest<List<GetAnswersByQuestionQueryResponse>>
    {
        public string QuestionId { get; set; }
    }
}
