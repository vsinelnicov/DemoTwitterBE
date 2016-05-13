using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DemoTwitter.DataAccessLayer.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly Twitter_dbEntities dbContext = new Twitter_dbEntities();
    
        public bool Register(User user)
        {
            if (user == null)
                return false;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return true;

        }

        public bool Update(User updatedUser)
        {
            if (updatedUser != null)
            {
                var update = dbContext.Users.FirstOrDefault(u => u.id == updatedUser.id);

                if (update != null &&
                    updatedUser.firstname == update.firstname &&
                    updatedUser.lastname == update.lastname &&
                    updatedUser.password == update.password)
                    return true;

                if (update != null)
                {
                    update.firstname = updatedUser.firstname;
                    update.lastname = updatedUser.lastname;
                    update.password = updatedUser.password;
                    dbContext.Entry(update).State = EntityState.Modified;
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Remove(User user)
        {
            if (user == null)
                return false;
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return true;
        }

        public User GetByUsername(string userName)
        {
            return dbContext.Users.FirstOrDefault(user => user.username == userName);
        }

        public User GetByEmail(string emailAddress)
        {
            return dbContext.Users.FirstOrDefault(user => user.email == emailAddress);
        }

        public IList<User> GetAll()
        {
            return dbContext.Users.ToList();
        }
    }
}