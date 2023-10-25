using MediatR;
using PsychologicalCounselingProject.Application.Abstraction.Services;
using PsychologicalCounselingProject.Application.DTOs.User;

namespace PsychologicalCounselingProject.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponseDto response = await _userService.CreateUserAsync(new() 
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                Username = request.Username 
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }
    }
}
