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

        public bool Add(Tweet tweet)
        {
            if (tweet == null)
            {
                return false;
            }
            DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
            tweetsRepository.Add(tweetForDatabase);
            return true;
        }

        public bool Remove(Tweet tweet)
        {
            if (tweet == null)
            {
                return false;
            }
            DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
            tweetsRepository.Remove(tweetForDatabase);
            return true;
        }

        public bool Update(Tweet oldTweet, Models.Tweet newTweet)
        {
            if (newTweet == null)
            {
                return false;
            }
            oldTweet.Text = newTweet.Text;
            oldTweet.PostDate = newTweet.PostDate;
            return true;
        }

        public IList<Tweet> GetAll()
        {

            return tweetsRepository.GetAll().Select(tweet => tweetMapper.MapToUserModel(tweet)).OrderByDescending(x => x.PostDate).ToList();

        }

        public IEnumerable<Tweet> GetByPostDate(DateTime postDate)
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
