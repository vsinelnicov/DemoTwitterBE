using System.Collections.Generic;

namespace DemoTwitter.DataAccessLayer.Tweets
{
    public interface ITweetsRepository
    {
        bool Add(Tweet tweet);
        bool Update(Tweet oldTweet, Tweet newTweet);
        bool Remove(Tweet tweet);
        IList<Tweet> GetAll();
    }
}
