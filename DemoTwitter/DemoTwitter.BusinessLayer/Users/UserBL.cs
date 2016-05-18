using System.Collections.Generic;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.Mapper;
using User = DemoTwitter.Models;

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

        public bool Register(User.User user)
        {
            if (user == null)
                return false;
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(user);
            usersRepository.Register(userForDatabase);
            return true;
        }

        public bool Remove(User.User user)
        {
            if (user == null)
                return false;
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(user);
            usersRepository.Remove(userForDatabase);
            return true;
        }

        public bool Update(User.User updatedUser)
        {
            if (updatedUser == null)
                return false;
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(updatedUser);
            usersRepository.Update(userForDatabase);
            return true;
        }

        public User.User GetByUsername(string userName)
        {
            return userMapper.MapToUserModel(usersRepository.GetByUsername(userName));
        }

        public User.User GetByEmail(string emailAddress)
        {
            return userMapper.MapToUserModel(usersRepository.GetByEmail(emailAddress));
        }

        public IEnumerable<User.User> GetAllUsers()
        {
            IEnumerable<DataAccessLayer.User> usersFromDatabase = usersRepository.GetAll();
            List<User.User> allUsers = new List<User.User>();

            foreach (var user in usersFromDatabase)
            {
                allUsers.Add(userMapper.MapToUserModel(user));
            }
            return allUsers;
        }
    }
}