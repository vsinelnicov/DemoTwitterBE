using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DemoTwitter.DataAccessLayer.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly Twitter_dbEntities dbContext = new Twitter_dbEntities();
        public void Add(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public void Update(User updatedUser)
        {
            dbContext.Users.Attach(updatedUser);
            DbEntityEntry<User> newUser = dbContext.Entry(updatedUser);
            newUser.Property(u => u.username).IsModified = true;
            newUser.Property(u => u.email).IsModified = true;
            newUser.Property(u => u.password).IsModified = true;
            newUser.Property(u => u.firstname).IsModified = true;
            newUser.Property(u => u.lastname).IsModified = true;
            dbContext.SaveChanges();
        }

        public void Remove(User user)
        {
            dbContext.Users.Remove(user);
        }

        public IList<User> GetAll()
        {
            return dbContext.Users.ToList();
        }
    }
}