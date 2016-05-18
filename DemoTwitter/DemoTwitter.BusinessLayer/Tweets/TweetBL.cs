using System;
using System.Collections.Generic;
using System.Linq;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.Mapper;
using Tweet = DemoTwitter.Models;

namespace DemoTwitter.BusinessLayer
{
    public class TweetBL : ITweetBL
    {
        private readonly ITweetsRepository tweetsRepository;
        private readonly ITweetMapper tweetMapper;

        public TweetBL(ITweetsRepository tweetsRepository, ITweetMapper tweetMapper)
        {
            this.tweetsRepository = tweetsRepository;
            this.tweetMapper = tweetMapper;
        }

        public bool Add(Tweet.Tweet tweet)
        {
            try
            {
                DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
                tweetsRepository.Add(tweetForDatabase);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(Tweet.Tweet tweet)
        {
            try
            {
                DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
                tweetsRepository.Remove(tweetForDatabase);
                return true;
            }
            catch (Exception)
            {
                //Log(blablabla, e);
                return false;
            }

        }

        public bool Update(Tweet.Tweet tweet)
        {
            try
            {
                //DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
                DataAccessLayer.Tweet tweetForDatabase = new DataAccessLayer.Tweet()
                {
                    id = 48,
                    user_id = 58,
                    text = "tralalala",
                    post_date = DateTime.Now
                };
                tweetsRepository.Update(tweetForDatabase);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IList<Tweet.Tweet> GetAll()
        {

            return tweetsRepository.GetAll().Select(tweet => tweetMapper.MapToUserModel(tweet)).OrderByDescending(x => x.PostDate).ToList();

        }
        public IEnumerable<Tweet.Tweet> GetByPostDate(DateTime postDate)
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
