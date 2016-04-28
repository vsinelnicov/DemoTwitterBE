﻿using System.Collections.Generic;

namespace DemoTwitter.DataAccessLayer.Users
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User updatedUser);
        void Remove(User user);
        IList<User> GetAll();
    }
}
