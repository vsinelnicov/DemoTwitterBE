using System.Collections.Generic;

namespace DemoTwitter.DataAccessLayer.Tweets
{
    public interface ITweetsRepository
    {
        void Add(Tweet tweet);
        void Update(Tweet oldTweet, Tweet newTweet);
        void Remove(Tweet tweet);
        IList<Tweet> GetAll();
    }
}
