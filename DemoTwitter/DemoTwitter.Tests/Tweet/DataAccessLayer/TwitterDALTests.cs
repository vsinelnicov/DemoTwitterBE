using System;
using DemoTwitter.DataAccessLayer.Tweets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoTwitter.Tests.Tweet.DataAccessLayer
{
    [TestClass]
    public class TwitterDALTests
    {
        ITweetsRepository tweetsRepository = new TweetsRepository();
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
        public void Add_ValidTweetAdded_ReturnsFalse()
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
        public void Remove_ValidTweetRemoved_ReturnsFalse()
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
                text = "Add Unit TestUPDATED!",
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
        public void Update_ValidTweetUpdated_ReturnsFalse()
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
