using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
using Enitition;

namespace Services
{
    public class UserService
    {
        UserRepository ur = new UserRepository();
        public IEnumerable<User> GetAllUsers()
        {
           return ur.GetAllUsers();
        }
        public User Login(LoginUser loginUser)
        {
            User user = ur.Login(loginUser);
            if (user != null)
                return user;
            return null;
        }
        public User GetUserById(int id)
        {
            return ur.GetUserById(id);
        }
        public User AddUser(User user)
        {
            return ur.AddUser(user);
        }

        public void DeleteUser(int id)
        {
             ur.DeleteUser(id);
        }

        public bool Update(User user)
        {
            return ur.UpdateUser(user);
        }

    }
}
