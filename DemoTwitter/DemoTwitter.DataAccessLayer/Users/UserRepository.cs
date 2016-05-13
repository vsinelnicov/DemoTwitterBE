using System.Collections.Generic;
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
            if (updatedUser == null)
                return false;
            dbContext.Users.Attach(updatedUser);
            DbEntityEntry<User> newUser = dbContext.Entry(updatedUser);
            newUser.Property(u => u.username).IsModified = true;
            newUser.Property(u => u.email).IsModified = true;
            newUser.Property(u => u.password).IsModified = true;
            newUser.Property(u => u.firstname).IsModified = true;
            newUser.Property(u => u.lastname).IsModified = true;
            dbContext.SaveChanges();
            return true;
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