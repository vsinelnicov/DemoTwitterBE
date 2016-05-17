using System;
using System.Data.Entity;


namespace DemoTwitter.DataAccessLayer
{
    public interface ITwitter_dbEntities
    {
         DbSet<Follower> Followers { get;}
         DbSet<Tweet> Tweets { get;}
         DbSet<User> Users { get;}
        int SaveChanges();
    }
}
