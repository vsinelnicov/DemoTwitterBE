
using DemoTwitter.Models;

namespace DemoTwitter.Mapper
{
    public class TweetMapper : ITweetMapper
    {
        public Tweet MapToUserModel(DataAccessLayer.Tweet tweetFromDatabase)
        {
            var tweet = new Tweet
            {
                Id = tweetFromDatabase.id,
                UserId = tweetFromDatabase.user_id,
                Text = tweetFromDatabase.text,
                PostDate = tweetFromDatabase.post_date
            };
            return tweet;
        }

        public DataAccessLayer.Tweet MapToDatabaseType(Tweet userModelTweet)
        {
            var tweet = new DataAccessLayer.Tweet
            {
                id = userModelTweet.Id,
                user_id = userModelTweet.UserId,
                text = userModelTweet.Text,
                post_date = userModelTweet.PostDate
            };
            return tweet;
        }
    }
}