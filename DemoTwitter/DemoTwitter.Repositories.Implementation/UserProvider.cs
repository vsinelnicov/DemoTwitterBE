using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using DemoTwitter.DomainModel;

namespace DemoTwitter.Repositories.Implementation
{
    [Export(typeof(IUserProvider))]
    public class UserProvider : IUserProvider
    {
        public UserProvider(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        private readonly IUserRepository userRepository;

        public User GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email);
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers();
        }
    }
}
