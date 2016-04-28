using System.Collections.Generic;
using System.Net;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.DataAccessLayer.Users;
using DemoTwitter.Mapper.Users;
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

        public void Update(User updatedUser)
        {
            DataAccessLayer.User userForDatabase = userMapper.MapToDatabaseType(updatedUser);
            usersRepository.Update(userForDatabase);
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
