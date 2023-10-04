using MediatR;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;

namespace PsychologicalCounselingProject.Application.Features.Queries.Module.GetModuleById
{
    public class GetModuleByIdQueryHandler : IRequestHandler<GetModuleByIdQueryRequest, GetModuleByIdQueryResponse>
    {
        readonly IModuleReadRepository _moduleReadRepository;

        public GetModuleByIdQueryHandler(IModuleReadRepository moduleReadRepository)
        {
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<GetModuleByIdQueryResponse> Handle(GetModuleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var module = await _moduleReadRepository.GetByIdAsync(request.Id);
            return new() { Name = module.Name, QuestionSize = module.QuestionSize };
        }
    }
}
