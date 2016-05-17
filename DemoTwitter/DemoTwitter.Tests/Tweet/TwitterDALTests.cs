using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTwitter.DataAccessLayer
{
    [TestClass]
    public class TwitterDALTests
    {
        public TwitterDALTests()
        { }
        [TestMethod]
        public void Add_Add_a_tweet_to_database()
        {
            var tweet = new Tweet
            {
                user_id = 3,
                text = "This is a unit test4444!",
                post_date = DateTime.Parse("2016-05-13 14:46:29.387")
            };
            var mockSet = new Mock<DbSet<Tweet>>();
            var mockContext = new Mock<Twitter_dbEntities>();
            mockContext.Setup(tweets => tweets.Tweets).Returns(mockSet.Object);
            ITweetsRepository service = new TweetsRepository(mockContext.Object);
            service.Add(tweet);
            mockSet.Verify(m => m.Add(It.IsAny<Tweet>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Update_update_an_existing_tweet_from_database()
        {
            var tweet = new List<Tweet>
            {
              new Tweet()
              {
                id  = 48,
                user_id = 58,
                text = "This is Didina's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:50:32.820")
              } ,
               new Tweet()
              {
                id  = 49,
                user_id = 61,
                text = "This is Eugen's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:50:47.957")
              } ,
               new Tweet()
              {
                id  = 50,
                user_id = 59,
                text = "This is Valeriu's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:51:43.610")
              }
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Tweet>>();
            var mockContext = new Mock<Twitter_dbEntities>();
            mockContext.Setup(tweets => tweets.Tweets).Returns(mockSet.Object);
            ITweetsRepository service = new TweetsRepository(mockContext.Object);
            service.Update(tweet.FirstOrDefault(x => x.id == 49));

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Remove_Remove_a_tweet_from_database()
        {
            var tweet = new List<Tweet>
            {
              new Tweet()
              {
                id  = 48,
                user_id = 58,
                text = "This is Didina's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:50:32.820")
              } ,
               new Tweet()
              {
                id  = 49,
                user_id = 61,
                text = "This is Eugen's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:50:47.957")
              } ,
               new Tweet()
              {
                id  = 50,
                user_id = 59,
                text = "This is Valeriu's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:51:43.610")
              }
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Tweet>>();
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.Provider).Returns(tweet.Provider);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.Expression).Returns(tweet.Expression);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.ElementType).Returns(tweet.ElementType);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.GetEnumerator()).Returns(tweet.GetEnumerator());
            var mockContext = new Mock<Twitter_dbEntities>();
            mockContext.Setup(t => t.Tweets).Returns(mockSet.Object);

            ITweetsRepository service = new TweetsRepository(mockContext.Object);
            service.Remove(tweet.FirstOrDefault(h => h.id == 49));
            mockSet.Verify(m => m.Remove(It.IsAny<Tweet>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Add_cant_add_an_invalid_tweet_to_database()
        {
            var tweet = new Tweet();
            tweet = null;

            var mockSet = new Mock<DbSet<Tweet>>();
            var mockContext = new Mock<Twitter_dbEntities>();
            mockContext.Setup(tweets => tweets.Tweets).Returns(mockSet.Object);
            bool expected = true;
            ITweetsRepository service = new TweetsRepository(mockContext.Object);
            bool actual = service.Add(tweet);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_cant_remove_an_unexisting_tweet_from_database()
        {
            var tweet = new List<Tweet>
            {
              new Tweet()
              {
                id  = 48,
                user_id = 58,
                text = "This is Didina's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:50:32.820")
              } ,
               new Tweet()
              {
                id  = 49,
                user_id = 61,
                text = "This is Eugen's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:50:47.957")
              } ,
               new Tweet()
              {
                id  = 50,
                user_id = 59,
                text = "This is Valeriu's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:51:43.610")
              }
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Tweet>>();
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.Provider).Returns(tweet.Provider);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.Expression).Returns(tweet.Expression);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.ElementType).Returns(tweet.ElementType);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.GetEnumerator()).Returns(tweet.GetEnumerator());
            var mockContext = new Mock<Twitter_dbEntities>();
            mockContext.Setup(t => t.Tweets).Returns(mockSet.Object);

            ITweetsRepository service = new TweetsRepository(mockContext.Object);
            bool actual = service.Remove(tweet.FirstOrDefault(h => h.id == 1));
            bool expected = true;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Update_cant_update_an_invalid_tweet_from_database()
        {
            var tweet = new Tweet();
            tweet = null;
            var mockSet = new Mock<DbSet<Tweet>>();
            var mockContext = new Mock<Twitter_dbEntities>();
            mockContext.Setup(tweets => tweets.Tweets).Returns(mockSet.Object);
            ITweetsRepository service = new TweetsRepository(mockContext.Object);
            bool expected = false;
            bool actual = service.Update(tweet);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetAll_GetAllTweetsFromDatabase()
        {
            var tweet = new List<Tweet>
            {
              new Tweet()
              {
                id  = 48,
                user_id = 58,
                text = "This is Didina's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:50:32.820")
              } ,
               new Tweet()
              {
                id  = 49,
                user_id = 61,
                text = "This is Eugen's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:50:47.957")
              } ,
               new Tweet()
              {
                id  = 50,
                user_id = 59,
                text = "This is Valeriu's First Post!",
                post_date = DateTime.Parse("2016-05-10 13:51:43.610")
              }
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Tweet>>();
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.Provider).Returns(tweet.Provider);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.Expression).Returns(tweet.Expression);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.ElementType).Returns(tweet.ElementType);
            mockSet.As<IQueryable<Tweet>>().Setup(m => m.GetEnumerator()).Returns(tweet.GetEnumerator());
            var mockContext = new Mock<Twitter_dbEntities>();
            mockContext.Setup(t => t.Tweets).Returns(mockSet.Object);

            ITweetsRepository service = new TweetsRepository(mockContext.Object);
            var tweets = service.GetAll();

            Assert.AreEqual(3, tweets.Count);
            Assert.AreEqual("This is Didina's First Post!", tweets[0].text);
            Assert.AreEqual("This is Eugen's First Post!", tweets[1].text);
            Assert.AreEqual("This is Valeriu's First Post!", tweets[2].text);

        }
    }
}
