using MediatR;
using Microsoft.AspNetCore.Identity;
using PsychologicalCounselingProject.Domain.Entities.Identity;

namespace PsychologicalCounselingProject.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                UserName = request.Username,
                Email = request.Email,
            }, request.Password);

            if(result.Succeeded)
            {
                return new CreateUserCommandResponse { Message = "User created successfully", Succeeded = result.Succeeded};
            }
            else
                foreach (var error in result.Errors)
                {
                    throw new Exception($"{error.Code} - {error.Description}");
                }

            return new();
        }
    }
}
