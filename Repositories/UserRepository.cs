using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Enitition;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{

    public class UserRepository : IUserRepository
    {
        StoreDbContext context = new StoreDbContext();
        static string filePath = "text.txt";
        
        public User GetUserById(int id)
        {
          
            User user = context.Users.FirstOrDefault(u => u.Id == id);
            return user;

        }

        public User Login(LoginUser loginUser)
        {
            User user = context.Users.FirstOrDefault(u => u.Email == loginUser.email && u.Password == loginUser.password);
            return user;
        }
        public async Task<User> AddUser(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
           
        }
        private static int passwordValidation(string password)
        {
            return 3;// Zxcvbn.Core.EvaluatePassword(password).Score;
        }
        public async  Task<bool> UpdateUser(User user)
        {
            User value =context.Users.ToList().FirstOrDefault(u => u.Id == user.Id);
            if(value == null)
                return false;
            context.Entry(value).CurrentValues.SetValues(user);
            await context.SaveChangesAsync();
            return true;
           
        }
        public async Task<bool> DeleteUser(int id)
        {
            User user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
               context.Users.Remove(user);
               await context.SaveChangesAsync();
            }
            return true;
        }
    }
}
