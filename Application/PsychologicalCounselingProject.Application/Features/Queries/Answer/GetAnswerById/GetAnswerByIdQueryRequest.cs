using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAnswerById
{
    public class GetAnswerByIdQueryRequest : IRequest<GetAnswerByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
