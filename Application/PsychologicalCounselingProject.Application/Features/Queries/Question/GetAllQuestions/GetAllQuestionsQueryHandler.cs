using MediatR;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Queries.Question.GetAllQuestions
{
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQueryRequest, GetAllQuestionsQueryResponse>
    {
        private readonly IQuestionReadRepository _questionReadRepository;

        public GetAllQuestionsQueryHandler(IQuestionReadRepository questionReadRepository)
        {
            _questionReadRepository = questionReadRepository;
        }

        public async Task<GetAllQuestionsQueryResponse> Handle(GetAllQuestionsQueryRequest request, CancellationToken cancellationToken)
        {
            var questions = _questionReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new { p.Title, p.Answer }).ToList();

            return new() { Questions = questions };
        }
    }
}
