
using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User Login(LoginUser loginUser);
        bool UpdateUser(User user);
    }
}