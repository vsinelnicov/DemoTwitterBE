using System;
using System.Text;
using System.Collections.Generic;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.DataAccessLayer.Tweets;
using DemoTwitter.DataAccessLayer.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DemoTwitter.Tests.Tweet.DataAccessLayer
{
    /// <summary>
    /// Summary description for TwitterDALTests
    /// </summary>
    [TestClass]
    public class TwitterDALTests
    {
        ITweetsRepository tweetsRepository = new TweetsRepository();
        Twitter_dbEntities db = new Twitter_dbEntities();
        public TwitterDALTests()
        {

        }
        [TestMethod]
        public void Add_ValidTweetAdded_ReturnsTrue()
        {
            //arrage
            var tweet = new DemoTwitter.DataAccessLayer.Tweet();
            tweet.text = "Add Unit Test!";
            tweet.post_date = DateTime.Now;
            tweet.user_id = 58;

            bool expected = true;
            //act
            bool actual = tweetsRepository.Add(tweet);
            //assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Add_ValidTweetAdded_ReturnsFalse()
        {
            //arrage
            var tweet = new DemoTwitter.DataAccessLayer.Tweet();
            tweet = null;

            bool expected = false;
            //act
            bool actual = tweetsRepository.Add(tweet);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ValidTweetRemoved_ReturnsTrue()
        {
            //arrage

            var tweet = new DemoTwitter.DataAccessLayer.Tweet();
            bool expected = true;
            tweet.id = 107;
            tweet.post_date = DateTime.Parse("2016-05-11 17:59:31.363");
            tweet.text = "Add Unit Test!";
            tweet.user_id = 58;
           //act
            bool actual = tweetsRepository.Remove(tweet);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ValidTweetRemoved_ReturnsFalse()
        {
            //arrage
            var tweet = new DemoTwitter.DataAccessLayer.Tweet();
            tweet = null;
            bool expected = false;
            //act
            bool actual = tweetsRepository.Remove(tweet);
            //assert
            Assert.AreEqual(expected, actual);
        }



    }
}
