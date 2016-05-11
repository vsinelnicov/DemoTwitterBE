using System;
using System.Collections.Generic;
using Tweet = DemoTwitter.Models.Tweet;

namespace DemoTwitter.BusinessLayer.Tweets
{
    public interface ITweetBL
    {
        bool Add(Tweet tweet);
        bool Remove(Tweet tweet);
        bool Update(Tweet oldTweet, Tweet newTweet);
        IList<Tweet> GetAll();
        IEnumerable<Tweet> GetByPostDate(DateTime postDate);
    }
}
