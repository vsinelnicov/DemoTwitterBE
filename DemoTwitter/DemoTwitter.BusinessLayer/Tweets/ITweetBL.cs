using System;
using System.Collections.Generic;
using Tweet = DemoTwitter.Models.Tweet;

namespace DemoTwitter.BusinessLayer.Tweets
{
    public interface ITweetBL
    {
        void Add(Tweet tweet);
        void Remove(Tweet tweet);
        void Update(Tweet oldTweet, Tweet newTweet);
        IList<Tweet> GetAll();
        IEnumerable<Tweet> GetByPostDate(DateTime postDate);
    }
}
