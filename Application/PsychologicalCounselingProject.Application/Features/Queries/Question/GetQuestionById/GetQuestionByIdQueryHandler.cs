using MediatR;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;

namespace PsychologicalCounselingProject.Application.Features.Queries.Question.GetQuestionById
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQueryRequest, GetQuestionByIdQueryResponse>
    {
        private readonly IQuestionReadRepository _questionReadRepository;

        public GetQuestionByIdQueryHandler(IQuestionReadRepository questionReadRepository)
        {
            _questionReadRepository = questionReadRepository;
        }

        public async Task<GetQuestionByIdQueryResponse> Handle(GetQuestionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionReadRepository.GetByIdAsync(request.Id, false);
            return new() { Title = question.Title };
        }
    }
}
