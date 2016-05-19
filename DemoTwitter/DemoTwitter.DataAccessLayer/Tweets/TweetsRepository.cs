using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace DemoTwitter.DataAccessLayer
{
    public class TweetsRepository : ITweetsRepository
    {
        private ITwitter_dbEntities _dbContext;

        public TweetsRepository(ITwitter_dbEntities dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool Add(Tweet tweet)
        {
            if (tweet==null)
            {
                return false;
            }
            _dbContext.Tweets.Add(tweet);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(Tweet tweet)
        {
            if (tweet == null)
            {
                return false;
            }
            //code here
            _dbContext.SaveChanges();
            return true;
        }

        public bool Remove(Tweet tweet)
        {
            if (tweet == null)
            {
                return false;
            }
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
