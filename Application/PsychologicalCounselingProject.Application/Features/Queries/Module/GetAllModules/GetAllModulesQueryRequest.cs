using MediatR;

namespace PsychologicalCounselingProject.Application.Features.Queries.Module.GetAllModules
{
    public class GetAllModulesQueryRequest : IRequest<GetAllModulesQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
