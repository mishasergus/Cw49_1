using Cw49_1.DTOs;
using Cw49_1.Models;

namespace Cw49_1.Mappers
{
    public static class UserMappingExtensions
    {
        public static UserDto ToDto(this UserEntity user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                Password = user.Password
            };
        }
        public static UserEntity ToEntity(this UserDto user)
        {
            return new UserEntity
            {
                UserName = user.UserName,
                Password = user.Password
            };
        }
    }
}
