using Cw49_1.DTOs;
using Cw49_1.Mappers;
using Cw49_1.Models;
using Cw49_1.Repositories;

namespace Cw49_1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthDto> LoginAsync(UserDto user)
        {
            if (!await _userRepository.IsUserExistsAsync(user.UserName))
                return null;
            UserEntity userEnt = await _userRepository.GetUserAsync(user.UserName);
            if (userEnt.Password != user.Password || userEnt.UserName != user.UserName)
                return null;
            var tokenString = TokenGenerator.GetToken(user);
            return new AuthDto { Token = tokenString, User = user };
        }
        public async Task<AuthDto> SignupAsync(UserDto user)
        {
            if (await _userRepository.IsUserExistsAsync(user.UserName))
                return null;
            await _userRepository.AddUserAsync(UserMappingExtensions.ToEntity(user));
            return CreateAuthResponse(user);
        }

        private AuthDto CreateAuthResponse(UserDto user)
        {
            var tokenString = TokenGenerator.GetToken(user);
            return new AuthDto { Token = tokenString, User = user };
        }
    }
}
