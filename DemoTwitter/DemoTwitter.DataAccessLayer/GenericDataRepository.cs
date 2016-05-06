using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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
    }
}
