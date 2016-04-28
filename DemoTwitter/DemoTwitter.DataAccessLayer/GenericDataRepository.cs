using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DemoTwitter.Models;

namespace DemoTwitter.DataAccessLayer
{
    public class GenericDataRepository<T> where T : class
    {
        private readonly Twitter_dbEntities dbContext = new Twitter_dbEntities();

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            IQueryable<T> dbQuery = dbContext.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            list = dbQuery.AsNoTracking().ToList();

            return list;
        }

        public IList<Tweet> GetAllTweetsFromDatabase()
        {
            List<Tweet> tweets = new List<Tweet>();

            foreach (var tweetFromDatabase in dbContext.Tweets)
            {
                tweets.Add(tweetFromDatabase);
            }
            return tweets;
        }
    }
}
