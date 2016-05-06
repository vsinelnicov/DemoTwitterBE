using System.Collections.Generic;

namespace DemoTwitter.DataAccessLayer.Users
{
    public interface IUserRepository
    {
        void Register(User user);
        void Update(User updatedUser);
        void Remove(User user);
        User GetByUsername(string userName);
        IList<User> GetAll();
    }
}
