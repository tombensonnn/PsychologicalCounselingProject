using MediatR;
using PsychologicalCounselingProject.Application.Repositories.AnswerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAnswerById
{
    public class GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQueryRequest, GetAnswerByIdQueryResponse>
    {
        readonly IAnswerReadRepository _answerReadRepository;

        public GetAnswerByIdQueryHandler(IAnswerReadRepository answerReadRepository)
        {
            _answerReadRepository = answerReadRepository;
        }

        public async Task<GetAnswerByIdQueryResponse> Handle(GetAnswerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var answer = await _answerReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Content = answer.Content,
            };
        }
    }
}
