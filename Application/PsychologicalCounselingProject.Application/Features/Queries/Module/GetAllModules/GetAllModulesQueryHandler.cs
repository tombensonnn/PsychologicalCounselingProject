using MediatR;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;

namespace PsychologicalCounselingProject.Application.Features.Queries.Module.GetAllModules
{
    public class GetAllModulesQueryHandler : IRequestHandler<GetAllModulesQueryRequest, GetAllModulesQueryResponse>
    {
        readonly IModuleReadRepository _moduleReadRepository;

        public GetAllModulesQueryHandler(IModuleReadRepository moduleReadRepository)
        {
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<GetAllModulesQueryResponse> Handle(GetAllModulesQueryRequest request, CancellationToken cancellationToken)
        {
            var modules = _moduleReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.QuestionSize
                }).ToList();

            return new() { Modules = modules };
        }
    }
}
