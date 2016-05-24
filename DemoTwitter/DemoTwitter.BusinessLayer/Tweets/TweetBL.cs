using System;
using System.Collections.Generic;
using System.Linq;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.Mapper;
using log4net;
using log4net.Config;
using Tweet = DemoTwitter.Models;

namespace DemoTwitter.BusinessLayer
{
    public class TweetBL : ITweetBL
    {
        private readonly ITweetsRepository tweetsRepository;
        private readonly ITweetMapper tweetMapper;
        private static readonly ILog log = LogManager.GetLogger(typeof(TweetBL));

        public TweetBL(ITweetsRepository tweetsRepository, ITweetMapper tweetMapper)
        {
            BasicConfigurator.Configure();
            this.tweetsRepository = tweetsRepository;
            this.tweetMapper = tweetMapper;
        }

        public bool Add(Tweet.Tweet tweet)
        {
            try
            {
                if (tweet == null)
                {
                    throw new NullReferenceException("Tweet is null");
                }
                DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
                tweetsRepository.Add(tweetForDatabase);
                log.Info("Tweet succesfully added");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return false;
            }
            return true;

        }

        public bool Remove(Tweet.Tweet tweet)
        {
            try
            {
                if (tweet == null)
                {
                    throw new NullReferenceException("Tweet is null");
                }
                DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
                tweetsRepository.Remove(tweetForDatabase);
                log.Info("Tweet succesfully removed");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return false;
            }
            return true;
        }

        public bool Update(Tweet.Tweet tweet)
        {
            try
            {
                if (tweet == null)
                {
                    throw new NullReferenceException("Tweet is null");
                }
                DataAccessLayer.Tweet tweetForDatabase = tweetMapper.MapToDatabaseType(tweet);
                tweetsRepository.Update(tweetForDatabase);
                log.Info("Tweet succesfully updated");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return false;
            }
            return true;
        }

        public IList<Tweet.Tweet> GetAll()
        {
            try
            {
                return tweetsRepository.GetAll().Select(tweet => tweetMapper.MapToUserModel(tweet)).OrderByDescending(x => x.PostDate).ToList();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Tweet.Tweet> GetByPostDate(DateTime postDate)
        {
            try
            {
                IEnumerable<DataAccessLayer.Tweet> tweetsFromDatabase = tweetsRepository.GetAll().Where(t => t.post_date == postDate);
                return tweetsFromDatabase.Select(tweet => tweetMapper.MapToUserModel(tweet)).ToList();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return null;
            }
        }
    }
}
