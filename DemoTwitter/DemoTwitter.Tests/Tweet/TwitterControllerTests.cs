using System.Web.Mvc;
using DemoTwitter.BusinessLayer;
using DemoTwitter.WEB.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTwitter.WEB.Controllers
{
    [TestClass]
    public class TwitterControllerTests
    {
        private Mock<TweetController> tweetControllerMock;
        private Mock<IUserBL> userBlMock;

        [TestInitialize]
        public void Initialization()
        {
            tweetControllerMock = new Mock<TweetController>();
            userBlMock = new Mock<IUserBL>();

        }
        [TestMethod]
        public void TestMethod1()
        {
             
        }
    }
}
