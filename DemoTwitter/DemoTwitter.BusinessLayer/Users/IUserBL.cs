﻿using System.Collections.Generic;
using DemoTwitter.Models;

namespace DemoTwitter.BusinessLayer.Users
{
    public interface IUserBL
    {

        void Add(User user);
        void Remove(User user);
        void Update(User oldUser, User newUser);
        IList<User> GetAll();

    }
}

