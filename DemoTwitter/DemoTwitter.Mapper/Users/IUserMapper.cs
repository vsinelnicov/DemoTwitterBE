using DemoTwitter.Models;

namespace DemoTwitter.Mapper.Users
{
    public interface IUserMapper
    {
        User MapToUserModel(DataAccessLayer.User userFromDatabase);
        DataAccessLayer.User MapToDatabaseType(User userModel);
        DataAccessLayer.User MapLoginUserToDatabaseType(LoginUserModel loginUser);
    }
}
