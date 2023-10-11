using MediatR;

namespace PsychologicalCounselingProject.Application.Features.Queries.Question.GetQuestionById
{
    public class GetQuestionByIdQueryRequest : IRequest<GetQuestionByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
