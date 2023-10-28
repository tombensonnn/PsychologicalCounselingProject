using MediatR;
using PsychologicalCounselingProject.Application.Repositories.AnswerRepositories;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;

namespace PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAnswersByQuestion
{
    public class GetAnswersByQuestionQueryHandler : IRequestHandler<GetAnswersByQuestionQueryRequest, List<GetAnswersByQuestionQueryResponse>>
    {
        readonly IQuestionReadRepository _questionReadRepository;
        readonly IAnswerReadRepository _answerReadRepository;

        public GetAnswersByQuestionQueryHandler(IQuestionReadRepository questionReadRepository, IAnswerReadRepository answerReadRepository)
        {
            _questionReadRepository = questionReadRepository;
            _answerReadRepository = answerReadRepository;
        }

        public async Task<List<GetAnswersByQuestionQueryResponse>> Handle(GetAnswersByQuestionQueryRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionReadRepository.GetByIdAsync(request.QuestionId);

            var answersList = _answerReadRepository.Table.Where(answer => answer.Question.Id == Guid.Parse(request.QuestionId)).Select(answer => new GetAnswersByQuestionQueryResponse()
            {
                Content = answer.Content
            }).ToList();

            return answersList;
        }
    }
}
