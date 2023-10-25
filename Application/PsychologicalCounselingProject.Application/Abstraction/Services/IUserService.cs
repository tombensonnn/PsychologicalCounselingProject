using PsychologicalCounselingProject.Application.DTOs.User;

namespace PsychologicalCounselingProject.Application.Abstraction.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateUserAsync(CreateUserDto createUserDto); 
    }
}
