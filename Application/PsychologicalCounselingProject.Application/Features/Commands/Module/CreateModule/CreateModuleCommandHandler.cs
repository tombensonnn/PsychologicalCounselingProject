using MediatR;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;
using PsychologicalCounselingProject.Application.Repositories.UserRepositories;

namespace PsychologicalCounselingProject.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommandRequest, CreateModuleCommandResponse>
    {
        readonly IModuleWriteRepository _moduleWriteRepository;
        readonly IUserReadRepository _userReadRepository;

        public CreateModuleCommandHandler(IModuleWriteRepository moduleWriteRepository, IUserReadRepository userReadRepository)
        {
            _moduleWriteRepository = moduleWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<CreateModuleCommandResponse> Handle(CreateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            var creatorUser = await _userReadRepository.GetByIdAsync(request.ConsultantId);
            var createdModule = await _moduleWriteRepository.AddAsync(new() {Name = request.Name, QuestionSize = request.QuestionSize, Consultant = creatorUser });
            await _moduleWriteRepository.SaveChangesAsync();

            return new() { Result = createdModule };
        }
    }
}
