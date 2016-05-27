using System.Collections.Generic;

namespace DemoTwitter.DataAccessLayer
{
    public interface IUserRepository
    {
        bool Register(User user);
        bool Update(User updatedUser);
        bool Remove(User user);
        void Follow(int followerId, int followedUserId);
        void UnFollow(int followerId, int followedUserId);
        bool IsFollowed(int followerId, int followedUserId);
        User GetByUsername(string userName);
        User GetByEmail(string emailAddress);
        User GetById(int Id);
        IList<User> GetAll();
    }
}