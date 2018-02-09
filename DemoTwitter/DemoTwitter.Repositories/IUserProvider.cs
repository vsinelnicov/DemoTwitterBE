using System.Collections.Generic;
using DemoTwitter.DomainModel;

namespace DemoTwitter.Repositories
{
    public interface IUserProvider
    {
        User GetUserByEmail(string email);
        User GetUserById(int id);
        IEnumerable<User> GetUsers();
    }
}
