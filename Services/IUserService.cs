
using Entities;
namespace Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        void DeleteUser(int id);
       // Task<IEnumerable<User>> GetAllUsers();
        User GetUserById(int id);
        User Login(LoginUser loginUser);
        Task<bool> Update(User user);
    }
}