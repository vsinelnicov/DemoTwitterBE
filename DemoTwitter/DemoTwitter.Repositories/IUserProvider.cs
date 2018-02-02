using System.Collections.Generic;
using DemoTwitter.DomainModel;

namespace DemoTwitter.Repositories
{
    public interface IUserProvider
    {
        string GetUserByEmail(string email);
        IEnumerable<User> GetUsers();
    }
}
