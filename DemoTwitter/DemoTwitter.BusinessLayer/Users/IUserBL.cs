using System.Collections.Generic;
using DemoTwitter.Models;

namespace DemoTwitter.BusinessLayer
{
    public interface IUserBL
    {
        bool Register(User user);
        bool Remove(User user);
        bool Update(User updatedUser);
        User GetByUsername(string userName);
        User GetByEmail(string emailAddress);
        User GetById(int id);
        IEnumerable<User> GetAllUsers();
        bool Follow(int followerId, int userToBeFollowed);
        bool UnFollow(int followerId, int followedUserId);
        bool IsFollowed(int followerId, int followedUserId);
    }
}

