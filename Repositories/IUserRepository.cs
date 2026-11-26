
using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<bool> DeleteUser(int id);
        User GetUserById(int id);
        User Login(LoginUser loginUser);
        Task<bool> UpdateUser(User user);
    }
}