using System.Collections.Generic;

namespace DemoTwitter.DataAccessLayer
{
    public interface ITweetsRepository
    {
        bool Add(Tweet tweet);
        bool Update(Tweet tweet);
        bool Remove(Tweet tweet);
        IList<Tweet> GetAll();
    }
}
