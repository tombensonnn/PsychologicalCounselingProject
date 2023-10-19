using MediatR;
using Microsoft.AspNetCore.Identity;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;
using PsychologicalCounselingProject.Domain.Entities.Identity;

namespace PsychologicalCounselingProject.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommandRequest, CreateModuleCommandResponse>
    {
        readonly IModuleWriteRepository _moduleWriteRepository;
        readonly UserManager<AppUser> _userManager;

        public CreateModuleCommandHandler(IModuleWriteRepository moduleWriteRepository, UserManager<AppUser> userManager)
        {
            _moduleWriteRepository = moduleWriteRepository;
            _userManager = userManager;
        }

        public async Task<CreateModuleCommandResponse> Handle(CreateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            //var creatorUser = await _userReadRepository.GetByIdAsync(request.ConsultantId);
            AppUser creatorUser = await _userManager.FindByIdAsync(request.ConsultantId);
            var createdModule = await _moduleWriteRepository.AddAsync(new() {Name = request.Name, QuestionSize = request.QuestionSize, Consultant = creatorUser });
            await _moduleWriteRepository.SaveChangesAsync();

            return new() { Result = createdModule };
        }
    }
}
