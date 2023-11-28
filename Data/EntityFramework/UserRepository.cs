using _19070006008_midterm.Data.Abstract;
using _19070006008_midterm.Models;
using System;
using System.Linq;

namespace _19070006008_midterm.Data.EntityFramework
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public User GetUserByUsername(string username)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var user = context.Users.SingleOrDefault(u => u.Username == username);
                    return user;
                }
                catch (Exception)
                {
                    // Handle the exception appropriately
                    // Log the error
                    // Consider throwing a custom exception or handling this case differently
                    return null;
                }
            }
        }

        public User GetUserByToken(string token)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var user = context.Users.SingleOrDefault(u => u.Token == token);
                    return user;
                }
                catch (Exception)
                {
                    
                    return null;
                }
            }
        }
    }
}
