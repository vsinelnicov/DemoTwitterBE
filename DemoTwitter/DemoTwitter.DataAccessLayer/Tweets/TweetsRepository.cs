using System.Collections.Generic;
using System.Linq;

namespace DemoTwitter.DataAccessLayer.Tweets
{
    public class TweetsRepository : ITweetsRepository
    {
        private readonly Twitter_dbEntities dbContext = new Twitter_dbEntities();

        public void Add(Tweet tweet)
        {
            dbContext.Tweets.Add(tweet);
            dbContext.SaveChanges();
        }

        public void Update(Tweet oldTweet, Tweet newTweet)
        {
            oldTweet.text = newTweet.text;
            oldTweet.post_date = newTweet.post_date;
        }

        public void Remove(Tweet tweet)
        {
            dbContext.Tweets.Remove(tweet);
            dbContext.SaveChanges();
        }

        public IList<Tweet> GetAll()
        {
            return dbContext.Tweets.ToList();
        }
    }
}
