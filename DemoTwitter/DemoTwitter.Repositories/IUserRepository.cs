using System.Collections.Generic;
using DemoTwitter.DomainModel;

namespace DemoTwitter.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user by the specified email.
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User data.</returns>
        User GetUserByEmail(string email);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>All users</returns>
        IEnumerable<User> GetUsers();
    }
}
