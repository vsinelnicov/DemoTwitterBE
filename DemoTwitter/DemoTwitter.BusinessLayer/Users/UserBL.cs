using System.Collections.Generic;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.Mapper;
using User = DemoTwitter.Models.User;

namespace DemoTwitter.BusinessLayer
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository usersRepository;
        private readonly IUserMapper userMapper;

        public UserBL(IUserRepository usersRepository, IUserMapper userMapper)
        {
            this.usersRepository = usersRepository;
            this.userMapper = userMapper;
        }

        public bool Register(User user)
        {
            if (user == null)
                return false;
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(user);
            usersRepository.Register(userForDatabase);
            return true;
        }

        public bool Remove(User user)
        {
            if (user == null)
                return false;
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(user);
            usersRepository.Remove(userForDatabase);
            return true;
        }

        public bool Update(User updatedUser)
        {
            if (updatedUser == null)
                return false;
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(updatedUser);
            usersRepository.Update(userForDatabase);
            return true;
        }

        public User GetByUsername(string userName)
        {
            return userMapper.MapToUserModel(usersRepository.GetByUsername(userName));
        }

        public User GetByEmail(string emailAddress)
        {
            return userMapper.MapToUserModel(usersRepository.GetByEmail(emailAddress));
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