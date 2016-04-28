using System.Collections.Generic;
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

        public void Update(User oldUser, User newUser)
        {
            oldUser.username = newUser.username;
            oldUser.email = newUser.email;
            oldUser.password = newUser.password;
            oldUser.firstname = newUser.firstname;
            oldUser.lastname = newUser.lastname;
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