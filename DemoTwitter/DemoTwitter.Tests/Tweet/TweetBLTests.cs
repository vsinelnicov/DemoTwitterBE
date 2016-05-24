using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tweet = DemoTwitter.Models.Tweet;


namespace DemoTwitter.BusinessLayer
{
    [TestClass]
    public class TwitterBLTests
    {
        private Mock<ITweetsRepository> tweetDALRepositoryMock;
        private Mock<ITweetMapper> tweetMapper;
        private ITweetBL service;
        private IQueryable<Tweet> tweetsList;
        private Tweet newTweet;

        [TestInitialize]
        public void Initialization()
        {
            tweetDALRepositoryMock = new Mock<ITweetsRepository>();
            tweetMapper = new Mock<ITweetMapper>();
            service = new TweetBL(tweetDALRepositoryMock.Object, tweetMapper.Object);
            newTweet = new Tweet
            {
                UserId = 3,
                Text = "This is a unit test4444!",
                PostDate = DateTime.Parse("2016-05-13 14:46:29.387")
            };
            tweetsList = new List<Tweet>
            {
              new Tweet
              {
                Id  = 48,
                UserId = 58,
                Text = "This is Didina's First Post!",
                PostDate = DateTime.Parse("2016-05-10 13:50:32.820")
              } ,
               new Tweet
              {
                Id  = 49,
                UserId = 61,
                Text = "This is Eugen's First Post!",
                PostDate = DateTime.Parse("2016-05-10 13:50:47.957")
              } ,
               new Tweet
              {
                Id  = 50,
                UserId = 59,
                Text = "This is Valeriu's First Post!",
                PostDate = DateTime.Parse("2016-05-10 13:51:43.610")
              }
               }.AsQueryable();
        }

        [TestMethod]
        public void Add_Add_a_valid_tweet_to_database_Returns_true()
        {
            bool expected = true;
            bool actual = service.Add(newTweet);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_Remove_a_valid_tweet_from_database_Returns_true()
        {
            bool expected = true;
            bool actual = service.Remove(tweetsList.FirstOrDefault(x => x.Id == 50));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Update_Update_a_valid_tweet_from_database_Returns_true()
        {
            bool expected = true;
            bool actual = service.Update(tweetsList.FirstOrDefault(x => x.Id == 50));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Update_Update_a_null_tweet_from_database_throw_Returns_false()
        {
            bool expected = service.Update(null);
            Assert.AreEqual(false, expected);
        }

        [TestMethod]
        public void Add_Add_a_null_tweet_from_database_Returns_false()
        {
            bool expected = service.Add(null);
            Assert.AreEqual(false, expected);
        }

        [TestMethod]
        public void Remove_Remove_a_null_tweet_from_database_Return_False()
        {
            bool expected = service.Remove(null);
            Assert.AreEqual(false, expected);
        }
    }
}
