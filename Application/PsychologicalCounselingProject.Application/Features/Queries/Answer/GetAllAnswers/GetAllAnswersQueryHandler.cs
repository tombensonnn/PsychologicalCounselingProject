using MediatR;
using PsychologicalCounselingProject.Application.Repositories.AnswerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAllAnswers
{
    public class GetAllAnswersQueryHandler : IRequestHandler<GetAllAnswersQueryRequest, List<GetAllAnswersQueryResponse>>
    {
        readonly IAnswerReadRepository _answerReadRepository;

        public GetAllAnswersQueryHandler(IAnswerReadRepository answerReadRepository)
        {
            _answerReadRepository = answerReadRepository;
        }

        public async Task<List<GetAllAnswersQueryResponse>> Handle(GetAllAnswersQueryRequest request, CancellationToken cancellationToken)
        {
            var answers = _answerReadRepository.GetAll(false).Skip(request.Size * request.Page).Take(request.Size).Select(answer => new GetAllAnswersQueryResponse()
            {
                AnswerId = answer.Id.ToString(),
                Content = answer.Content,
            }).ToList();

            return answers;
        }
    }
}
