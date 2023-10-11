using MediatR;

namespace PsychologicalCounselingProject.Application.Features.Queries.Question.GetAllQuestions
{
    public class GetAllQuestionsQueryRequest : IRequest<GetAllQuestionsQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
