using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

        public bool Update(Tweet tweet)
        {
            if (tweet == null)
                return false;
            dbContext.Tweets.Attach(tweet);
            DbEntityEntry<Tweet> newTweet = dbContext.Entry(tweet);
            newTweet.Property(u => u.id).IsModified = true;
            newTweet.Property(u => u.post_date).IsModified = true;
            newTweet.Property(u => u.text).IsModified = true;
            newTweet.Property(u => u.user_id).IsModified = true;

            dbContext.SaveChanges();
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
