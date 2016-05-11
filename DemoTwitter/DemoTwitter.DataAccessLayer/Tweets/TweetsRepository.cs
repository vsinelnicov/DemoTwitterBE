using System.Collections.Generic;
using System.Linq;

namespace DemoTwitter.DataAccessLayer.Tweets
{
    public class TweetsRepository : ITweetsRepository
    {
        private readonly Twitter_dbEntities dbContext = new Twitter_dbEntities();

        public bool Add(Tweet tweet)
        {
            if (tweet == null)
            {
                return false;
            }
            dbContext.Tweets.Add(tweet);
            dbContext.SaveChanges();
            return true;
        }

        public bool Update(Tweet oldTweet, Tweet newTweet)
        {
            if (newTweet == null)
            {
                return false;
            }
            oldTweet.text = newTweet.text;
            oldTweet.post_date = newTweet.post_date;
            return true;
        }

        public bool Remove(Tweet tweet)
        {
            if (tweet == null)
            {
                return false;
            }
            dbContext.Tweets.Remove(tweet);
            dbContext.SaveChanges();
            return true;
        }

        public IList<Tweet> GetAll()
        {
            return dbContext.Tweets.ToList();
        }
    }
}
