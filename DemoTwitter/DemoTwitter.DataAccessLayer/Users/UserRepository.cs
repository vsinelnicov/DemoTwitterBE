using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoTwitter.DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly ITwitter_dbEntities _dbContext;

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
                    updatedUser.password == update.password &&
                    updatedUser.email == update.email)
                    return true;

                if (update != null)
                {
                    update.firstname = updatedUser.firstname;
                    update.lastname = updatedUser.lastname;
                    update.password = updatedUser.password;
                }
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Remove(User user)
        {
            User userToRemove = GetById(user.id);
            _dbContext.Users.Remove(userToRemove);
            _dbContext.SaveChanges();
            return true;
        }

        public Follower GetFollower(int folowerId, int userId)
        {
            return _dbContext.Followers.FirstOrDefault(f => f.follower_id == folowerId && f.user_id == userId);
        }

        public void Follow(int followerId, int followedUserId)
        {
            Follower follower = new Follower
            {
                follower_id = followerId,
                user_id = followedUserId
            };

            if (!IsFollowed(followerId, followedUserId))
            {
                _dbContext.Followers.Add(follower);
                _dbContext.SaveChanges();
            }
        }

        public void UnFollow(int followerId, int followedUserId)
        {
            Follower follower = GetFollower(followerId, followedUserId);

            if (IsFollowed(followerId, followedUserId))
            {
                _dbContext.Followers.Remove(follower);
                _dbContext.SaveChanges();
            }
        }

        public bool IsFollowed(int followerId, int followedUserId)
        {
            var followedUser = _dbContext.Followers.FirstOrDefault(f => f.user_id == followedUserId && followerId == f.follower_id);
            if (followedUser == null)
                return false;
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
        public User GetById(int Id)
        {
            return _dbContext.Users.FirstOrDefault(user => user.id == Id);
        }

        public IList<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }
    }
}