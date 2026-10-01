using Cw49_1.DTOs;

namespace Cw49_1.Services
{
    public interface IUserService
    {
        Task<AuthDto> LoginAsync(UserDto user);
        Task<AuthDto> SignupAsync(UserDto user);
    }
}
