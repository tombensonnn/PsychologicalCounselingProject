using MediatR;
using Microsoft.AspNetCore.Identity;
using PsychologicalCounselingProject.Application.Abstraction.Services;
using PsychologicalCounselingProject.Application.DTOs.User;
using PsychologicalCounselingProject.Application.Features.Commands.User.CreateUser;
using PsychologicalCounselingProject.Domain.Entities.Identity;

namespace PsychologicalCounselingProject.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = createUserDto.Name,
                UserName = createUserDto.Username,
                Email = createUserDto.Email,
            }, createUserDto.Password);

            if (result.Succeeded)
            {
                return new CreateUserResponseDto { Message = "User created successfully", Succeeded = result.Succeeded };
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
