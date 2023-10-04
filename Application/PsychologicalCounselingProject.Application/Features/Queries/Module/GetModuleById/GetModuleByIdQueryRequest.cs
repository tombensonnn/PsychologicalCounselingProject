using MediatR;

namespace PsychologicalCounselingProject.Application.Features.Queries.Module.GetModuleById
{
    public class GetModuleByIdQueryRequest : IRequest<GetModuleByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
