using System;
using System.Collections.Generic;
using System.Linq;
using DemoTwitter.DataAccessLayer.Tweets;
using DemoTwitter.Mapper.Tweets;
using Tweet = DemoTwitter.Models.Tweet;

namespace DemoTwitter.BusinessLayer.Tweets
{
    public class TweetBL : ITweetBL
    {
        private readonly ITweetsRepository tweetsRepository = new TweetsRepository();
        private readonly ITweetMapper tweetMapper = new TweetMapper();


        public void Add(Models.Tweet tweet)
        {
            DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
            tweetsRepository.Add(tweetForDatabase);
        }

        public void Remove(Models.Tweet tweet)
        {
            DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
            tweetsRepository.Remove(tweetForDatabase);
        }

        public void Update(Models.Tweet oldTweet, Models.Tweet newTweet)
        {
            oldTweet.Text = newTweet.Text;
            oldTweet.PostDate = newTweet.PostDate;
        }

        public IEnumerable<Models.Tweet> GetByPostDate(DateTime postDate)
        {
            IEnumerable<DataAccessLayer.Tweet> tweetsFromDatabase = tweetsRepository.GetAll().Where(t => t.post_date == postDate);
            List<Models.Tweet> allTweets = new List<Models.Tweet>();

            foreach (var tweet in tweetsFromDatabase)
            {
                allTweets.Add(tweetMapper.MapToUserModel(tweet));
            }

            return allTweets;
        }
    }
}
