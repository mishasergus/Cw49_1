using Cw49_1.Models;

namespace Cw49_1.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsUserExistsAsync(string userName);
        Task<UserEntity?> GetUserAsync(string userName);
        Task AddUserAsync(UserEntity user);
    }
}
