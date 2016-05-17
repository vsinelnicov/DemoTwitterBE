
using System;
using System.Collections.Generic;
       
using System.Data.Entity;
using System.Linq;
using DemoTwitter.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;




namespace DemoTwitter.DataAccessLayer
{
    [TestClass]
    public class TwitterDALTests
    {
        //public readonly ITweetsRepository tweetsRepository;
        //public TwitterDALTests(TweetsRepository tweetsRepository)
        //{
        //    this.tweetsRepository = tweetsRepository;
        //}


        public TwitterDALTests()
        {
            IList<Tweet> tweets = new List<Tweet>
            {
                new Tweet
                {
                    id = 1,
                    user_id = 1,
                    text = "This is a unit test!" ,
                    post_date = DateTime.Parse("2016-05-10 14:14:59.860")
                },
                new Tweet
                {
                    id = 2,
                    user_id = 2,
                    text = "This is a unit test111!" ,
                    post_date = DateTime.Parse("2016-05-11 14:00:54.123")
                },
                new Tweet
                {
                    id = 3,
                    user_id = 3,
                    text = "This is a unit test2222!",
                   post_date = DateTime.Parse("2016-05-13 14:53:29.387")
                }
            };

        }
        [TestMethod]
        public void Add_ValidTweetAdded_ReturnsTrue()
        {
            Tweet tweet = new Tweet
            {
                id = 4,
                user_id = 3,
                text = "This is a unit test4444!",
                post_date = DateTime.Parse("2016-05-13 14:46:29.387")    
            };
            //IQueryable<Tweet> tmp = new DbSet<Tweet>();
            //tmp.Add(tweet);
            var mockSet = new Mock<DbSet<Tweet>>();
            var mockContext = new Mock<Twitter_dbEntities>();
            mockContext.Setup(tweets => tweets.Tweets).Returns(mockSet.Object);

            ITweetsRepository service = new TweetsRepository(mockContext.Object);
            service.Add(tweet);

            mockSet.Verify(m => m.Add(It.IsAny<Tweet>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}
