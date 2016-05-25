using System;
using System.Collections.Generic;
using System.Linq;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.Mapper;
using log4net;
using User = DemoTwitter.Models.User;

namespace DemoTwitter.BusinessLayer
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository usersRepository;
        private readonly IUserMapper userMapper;
        private readonly ITweetsRepository tweetsRepository;
        private static readonly ILog log = LogManager.GetLogger(typeof(UserBL));

        public UserBL(IUserRepository usersRepository, IUserMapper userMapper, TweetsRepository tweetsRepository)
        {
            this.usersRepository = usersRepository;
            this.userMapper = userMapper;
            this.tweetsRepository = tweetsRepository;
        }

        public bool Register(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new NullReferenceException();
                }
                DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(user);
                usersRepository.Register(userForDatabase);
                log.Info("User successfully registered");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return false;
            }
            return true;
        }

        public bool Remove(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new NullReferenceException();
                }
                DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(user);
                
                foreach (var tweet in tweetsRepository.GetAll().Where(tweet => tweet.user_id == user.Id))
                {
                    tweetsRepository.Remove(tweet);
                }
                usersRepository.Remove(userForDatabase);
                log.Info("Use deleted his/her accounts");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return false;
            }
            return true;
        }

        public bool Update(User updatedUser)
        {
            try
            {
                if (updatedUser == null)
                {
                    throw new NullReferenceException();
                }
                DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(updatedUser);
                usersRepository.Update(userForDatabase);
                log.Info("User updated his information");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return false;
            }
            return true;
        }

        public User GetByUsername(string userName)
        {
            return userMapper.MapToUserModel(usersRepository.GetByUsername(userName));
        }

        public User GetByEmail(string emailAddress)
        {
            return usersRepository.GetByEmail(emailAddress) == null ? null : userMapper.MapToUserModel(usersRepository.GetByEmail(emailAddress));
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<DataAccessLayer.User> usersFromDatabase = usersRepository.GetAll();
            List<User> allUsers = new List<User>();

            foreach (var user in usersFromDatabase)
            {
                allUsers.Add(userMapper.MapToUserModel(user));
            }
            return allUsers;
        }

        public bool Follow(int followerId, int followedUserId)
        {
            usersRepository.Follow(followerId, followedUserId);
            return true;
        }

        public bool UnFollow(int followerId, int followedUserId)
        {
            usersRepository.UnFollow(followerId, followedUserId);
            return true;
        }

        public bool IsFollowed(int followerId, int followedUserId)
        {
            return usersRepository.IsFollowed(followerId, followedUserId);
        }
    }
}