using System.Collections.Generic;

namespace DemoTwitter.DataAccessLayer
{
    public interface IUserRepository
    {
        bool Register(User user);
        bool Update(User updatedUser);
        bool Remove(User user);
        User GetByUsername(string userName);
        User GetByEmail(string emailAddress);
        IList<User> GetAll();
    }
}
