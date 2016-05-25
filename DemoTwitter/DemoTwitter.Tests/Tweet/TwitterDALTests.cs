using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DemoTwitter.BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTwitter.DataAccessLayer
{
    [TestClass]
    public class TwitterDALTests
    {
        //private IQueryable<Tweet> tweet;
        //private Tweet newTweet;
        //private Mock<DbSet<Tweet>> mockSet;
        //private Mock<Twitter_dbEntities> mockContext;
        //private ITweetsRepository service;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    newTweet = new Tweet
        //    {
        //        user_id = 3,
        //        text = "This is a unit test4444!",
        //        post_date = DateTime.Parse("2016-05-13 14:46:29.387")
        //    };
        //    tweet = new List<Tweet>
        //    {
        //      new Tweet
        //      {
        //        id  = 48,
        //        user_id = 58,
        //        text = "This is Didina's First Post!",
        //        post_date = DateTime.Parse("2016-05-10 13:50:32.820")
        //      } ,
        //       new Tweet
        //      {
        //        id  = 49,
        //        user_id = 61,
        //        text = "This is Eugen's First Post!",
        //        post_date = DateTime.Parse("2016-05-10 13:50:47.957")
        //      } ,
        //       new Tweet
        //      {
        //        id  = 50,
        //        user_id = 59,
        //        text = "This is Valeriu's First Post!",
        //        post_date = DateTime.Parse("2016-05-10 13:51:43.610")
        //      },
        //       }.AsQueryable();
        //    mockSet = new Mock<DbSet<Tweet>>();
        //    mockContext = new Mock<Twitter_dbEntities>();
        //    mockContext.Setup(tweets => tweets.Tweets).Returns(mockSet.Object);
        //    service = new TweetsRepository(mockContext.Object);
        //    mockSet.As<IQueryable<Tweet>>().Setup(m => m.Provider).Returns(tweet.Provider);
        //    mockSet.As<IQueryable<Tweet>>().Setup(m => m.Expression).Returns(tweet.Expression);
        //    mockSet.As<IQueryable<Tweet>>().Setup(m => m.ElementType).Returns(tweet.ElementType);
        //    mockSet.As<IQueryable<Tweet>>().Setup(m => m.GetEnumerator()).Returns(tweet.GetEnumerator());
        //}

        //[TestMethod]
        //public void Add_Add_a_tweet_to_database()
        //{
        //    service.Add(newTweet);
        //    mockSet.Verify(m => m.Add(It.IsAny<Tweet>()), Times.Once);
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once());
        //}

        //[TestMethod]
        //public void Update_Update_a_null_tweet_from_database_Returns_false()
        //{
        //    bool actual = service.Update(null);
        //    bool expected = false;
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Remove_Remove_a_tweet_from_database()
        //{
        //    service.Remove(tweet.FirstOrDefault(h => h.id == 49));
        //    mockSet.Verify(m => m.Remove(It.IsAny<Tweet>()), Times.Once);
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once());
        //}

        //[TestMethod]
        //public void GetAll_GetAllTweetsFromDatabase()
        //{
        //    var tweets = service.GetAll();
        //    Assert.AreEqual(3, tweets.Count);
        //    Assert.AreEqual("This is Didina's First Post!", tweets[0].text);
        //    Assert.AreEqual("This is Eugen's First Post!", tweets[1].text);
        //    Assert.AreEqual("This is Valeriu's First Post!", tweets[2].text);
        //}
    }
}
