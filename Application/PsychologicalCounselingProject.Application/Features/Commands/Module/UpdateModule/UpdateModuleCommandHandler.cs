using MediatR;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;

namespace PsychologicalCounselingProject.Application.Features.Commands.Module.UpdateModule
{
    public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommandRequest, UpdateModuleCommandResponse>
    {
        readonly IModuleReadRepository _moduleReadRepository;
        readonly IModuleWriteRepository _moduleWriteRepository;

        public UpdateModuleCommandHandler(IModuleWriteRepository moduleWriteRepository, IModuleReadRepository moduleReadRepository)
        {
            _moduleWriteRepository = moduleWriteRepository;
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<UpdateModuleCommandResponse> Handle(UpdateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedModule = await _moduleReadRepository.GetByIdAsync(request.Id);
            updatedModule.Name = request.Name;
            updatedModule.QuestionSize = request.QuestionSize;
            await _moduleWriteRepository.SaveChangesAsync();

            return new() { Module = updatedModule };
        }
    }
}
