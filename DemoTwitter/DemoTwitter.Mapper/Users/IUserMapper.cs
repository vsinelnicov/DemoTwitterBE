using DemoTwitter.Models;

namespace DemoTwitter.Mapper
{
    public interface IUserMapper
    {
        User MapToUserModel(DataAccessLayer.User userFromDatabase);
        DataAccessLayer.User MapToDatabaseType(User userModel);
    }
}
