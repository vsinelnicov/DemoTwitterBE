using System.Collections.Generic;
using System.Linq;
using log4net;


namespace DemoTwitter.DataAccessLayer
{
    public class TweetsRepository : ITweetsRepository
    {
        private ITwitter_dbEntities _dbContext;

        private static ILog log = LogManager.GetLogger(typeof(TweetsRepository));

        public TweetsRepository(ITwitter_dbEntities dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool Add(Tweet tweet)
        {
            _dbContext.Tweets.Add(tweet);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(Tweet updatedTweet)
        {
            if (updatedTweet != null)
            {
                var update = _dbContext.Tweets.FirstOrDefault(u => u.id == updatedTweet.id);

                if (update != null &&
                    updatedTweet.text == update.text &&
                    updatedTweet.post_date == update.post_date)
                    return true;
                if (update != null)
                {
                    update.text = updatedTweet.text;
                    update.post_date = updatedTweet.post_date;
                }
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Remove(Tweet tweet)
        {
            _dbContext.Tweets.Remove(tweet);
            _dbContext.SaveChanges();
            return true;
        }

        public IList<Tweet> GetAll()
        {
            return _dbContext.Tweets.ToList();
        }
    }
}
