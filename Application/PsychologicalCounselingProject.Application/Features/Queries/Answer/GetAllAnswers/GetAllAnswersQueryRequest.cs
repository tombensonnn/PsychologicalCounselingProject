using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAllAnswers
{
    public class GetAllAnswersQueryRequest : IRequest<List<GetAllAnswersQueryResponse>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
