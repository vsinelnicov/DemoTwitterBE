using System;
using System.Collections.Generic;
using System.Linq;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.DataAccessLayer.Users;
using DemoTwitter.Mapper.Users;
using Tweet = DemoTwitter.Models.Tweet;
using User = DemoTwitter.Models.User;

namespace DemoTwitter.BusinessLayer.Users
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository usersRepository = new UserRepository();
        private readonly IUserMapper userMapper = new UserMapper();

        public void Add(User user)
        {
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(user);
            usersRepository.Add(userForDatabase);
        }

        public void Remove(User user)
        {
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(user);
            usersRepository.Remove(userForDatabase);
        }

        public void Update(User oldUser, User newUser)
        {
            oldUser.Username = newUser.Username;
            oldUser.Email = newUser.Email;
            oldUser.Password = newUser.Password;
            oldUser.FirstName = newUser.FirstName;
            oldUser.LastName = newUser.LastName;

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
    }
}
