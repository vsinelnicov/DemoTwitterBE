using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoTwitter.Models;
using Tweet = DemoTwitter.Models.Tweet;

namespace DemoTwitter.BusinessLayer.Tweets
{
    public interface ITweetBL
    {
        void Add(Tweet tweet);
        void Remove(Tweet tweet);
        void Update(Tweet oldTweet, Tweet newTweet);
        IEnumerable<Tweet> GetByPostDate(DateTime postDate);
    }
}
