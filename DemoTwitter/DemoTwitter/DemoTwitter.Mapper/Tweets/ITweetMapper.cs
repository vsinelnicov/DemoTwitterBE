using DemoTwitter.Models;

namespace DemoTwitter.Mapper.Tweets
{
    public interface ITweetMapper
    {
        Tweet MapToUserModel(DataAccessLayer.Tweet tweetFromDatabase);

        DataAccessLayer.Tweet MapToDatabaseType(Tweet userModelTweet);
    }
}
