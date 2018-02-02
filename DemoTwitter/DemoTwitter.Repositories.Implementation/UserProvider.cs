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

        public string GetUserByEmail(string email)
        {
            var user = new User();
            user = userRepository.GetUserByEmail(email);
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers();
        }
    }
}
