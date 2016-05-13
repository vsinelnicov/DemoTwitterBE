using System;
using DemoTwitter.DataAccessLayer.Tweets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace DemoTwitter.Tests.Tweet.DataAccessLayer
{
    [TestClass]
    public class TwitterDALTests
    {
        private readonly ITweetsRepository tweetsRepository;

        public TwitterDALTests(ITweetsRepository tweetsRepository)
        {
            this.tweetsRepository = tweetsRepository;
        }

        public TwitterDALTests()
        {

        }
        [TestMethod]
        public void Add_ValidTweetAdded_ReturnsTrue()
        {
            //arrange
            var tweet = new DemoTwitter.DataAccessLayer.Tweet
            {
                text = "Add Unit Test!",
                post_date = DateTime.Now,
                user_id = 58
            };

            bool expected = true;
            //act
            bool actual = tweetsRepository.Add(tweet);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Add_InvalidTweetAdded_ReturnsFalse()
        {
            //arrange
            var tweet = new DemoTwitter.DataAccessLayer.Tweet();
            tweet = null;

            bool expected = false;
            //act
            bool actual = tweetsRepository.Add(tweet);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_InvalidTweetRemoved_ReturnsFalse()
        {
            //arrange
            var tweet = new DemoTwitter.DataAccessLayer.Tweet();
            tweet = null;
            bool expected = false;
            //act
            bool actual = tweetsRepository.Remove(tweet);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Update_ValidTweetUpdated_ReturnsTrue()
        {
            //arrange
            var tweet = new DemoTwitter.DataAccessLayer.Tweet
            {
                id = 107,
                text = "Add Unit Test!UPDATED!",
                post_date = DateTime.Now,
                user_id = 58
            };
            bool expected = true;
            //act
            bool actual = tweetsRepository.Update(tweet);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Update_InvalidTweetUpdated_ReturnsFalse()
        {
            //arrange
            var tweet = new DemoTwitter.DataAccessLayer.Tweet();
            tweet = null;
            bool expected = false;
            //act
            bool actual = tweetsRepository.Update(tweet);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
