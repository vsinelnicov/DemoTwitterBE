using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using log4net;

namespace DemoTwitter.DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly ITwitter_dbEntities _dbContext;
        private static readonly ILog log = LogManager.GetLogger(typeof(TweetsRepository));

        public UserRepository(ITwitter_dbEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Register(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(User updatedUser)
        {
            if (updatedUser != null)
            {
                var update = _dbContext.Users.FirstOrDefault(u => u.id == updatedUser.id);

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
                    //   dbContext.Entry(update).State = EntityState.Modified;
                }
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Remove(User user)
        {
            if (user == null)
                return false;
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        public User GetByUsername(string userName)
        {
            return _dbContext.Users.FirstOrDefault(user => user.username == userName);
        }

        public User GetByEmail(string emailAddress)
        {
            return _dbContext.Users.FirstOrDefault(user => user.email == emailAddress);
        }

        public IList<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }
    }
}