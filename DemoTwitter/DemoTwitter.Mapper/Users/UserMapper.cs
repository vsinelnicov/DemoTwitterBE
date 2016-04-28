using System;
using System.Security.Cryptography;
using DemoTwitter.Models;

namespace DemoTwitter.Mapper.Users
{
    public class UserMapper : IUserMapper
    {
        public User MapToUserModel(DataAccessLayer.User userFromDatabase)
        {
            var user = new User
               {
                   ID = userFromDatabase.id,
                   Username = userFromDatabase.username,
                   Email = userFromDatabase.email,
                   Password = userFromDatabase.password,
                   FirstName = userFromDatabase.firstname,
                   LastName = userFromDatabase.lastname

               };
            return user;
        }

        public DataAccessLayer.User MapToDatabaseType(User userModel)
        {
            var user = new DataAccessLayer.User
            {
                id = userModel.ID,
                username = userModel.Username,
                email = userModel.Email,
                password = userModel.Password,
                firstname = userModel.FirstName,
                lastname = userModel.LastName

            };
            return user;
        }
    }
}
