using DemoTwitter.Models;

namespace DemoTwitter.Mapper
{
    public class UserMapper : IUserMapper
    {
        public User MapToUserModel(DataAccessLayer.User userFromDatabase)
        {
            if (userFromDatabase == null)
            {
                return null;
            }

            var user = new User
            {
                Id = userFromDatabase.id,
                Username = userFromDatabase.username,
                Email = userFromDatabase.email,
                Password = userFromDatabase.password,
                FirstName = userFromDatabase.firstname,
                LastName = userFromDatabase.lastname,
                Avatar = userFromDatabase.avatar
            };
            return user;
        }

        public DataAccessLayer.User MapToDatabaseType(User userModel)
        {
            if (userModel == null)
            {
                return null;
            }
            var user = new DataAccessLayer.User
            {
                id = userModel.Id ?? 0,
                username = userModel.Username,
                email = userModel.Email,
                password = userModel.Password,
                firstname = userModel.FirstName,
                lastname = userModel.LastName,
                avatar = userModel.Avatar
                
            };
            return user;
        }

    }
}