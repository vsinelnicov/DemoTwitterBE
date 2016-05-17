using System;
using System.Collections.Generic;
using DemoTwitter.Models;

namespace DemoTwitter.BusinessLayer
{
    public interface ITweetBL
    {
        bool Add(Tweet tweet);
        bool Remove(Tweet tweet);
        bool Update(Tweet tweet);
        IList<Tweet> GetAll();
        IEnumerable<Tweet> GetByPostDate(DateTime postDate);
    }
}
