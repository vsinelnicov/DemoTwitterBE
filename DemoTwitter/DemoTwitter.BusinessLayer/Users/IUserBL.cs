using System.Collections.Generic;
using DemoTwitter.Models;

namespace DemoTwitter.BusinessLayer
{
    public interface IUserBL
    {
        void Register(User user);
        void Remove(User user);
        void Update(User updatedUser);
        User GetByUsername(string userName);
        User GetByEmail(string emailAddress);
        IEnumerable<User> GetAllUsers();
    }
}

