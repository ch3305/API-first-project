using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Enitition;
using Entities;


namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        static string filePath = "text.txt";
        public IEnumerable<User> GetAllUsers()
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                List<User> users = new List<User>();
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    users.Add(user);

                }
                return users;
            }
            return null;

        }
        public User GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if(user.id==id)
                        return user;

                }
              
            }
            return null;

        }

        public User Login(LoginUser loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password == loginUser.password)
                        return user;
                }
            }
            return null;
        }
        public User AddUser(User user)
        {
            if (passwordValidation(user.password) <= 2)
            {
                return null;
            }
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }
        private static int passwordValidation(string password)
        {
            return 3;// Zxcvbn.Core.EvaluatePassword(password).Score;
        }
        public bool UpdateUser(User user)
        {
            if (user == null)
                return false;
            if (!System.IO.File.Exists(filePath))
            {
                return false;
            }
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user1 = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user1.id == user.id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText(filePath, text);
            }
            return true;
        }
        public void DeleteUser(int id)
        {

        }
    }
}
