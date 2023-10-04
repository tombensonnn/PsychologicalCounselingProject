using MediatR;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Module.DeleteModule
{
    public class DeleteModuleCommandHandler : IRequestHandler<DeleteModuleCommandRequest, DeleteModuleCommandResponse>
    {
        readonly IModuleWriteRepository _moduleWriteRepository;

        public DeleteModuleCommandHandler(IModuleWriteRepository moduleWriteRepository)
        {
            _moduleWriteRepository = moduleWriteRepository;
        }

        public async Task<DeleteModuleCommandResponse> Handle(DeleteModuleCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedModule = await _moduleWriteRepository.RemoveAsync(request.Id);
            await _moduleWriteRepository.SaveChangesAsync();
            return new() { Result = deletedModule };
        }
    }
}
