using System;
using System.Linq;
using DemoTwitter.DataAccessLayer;
using DemoTwitter.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using User = DemoTwitter.Models.User;

namespace DemoTwitter.BusinessLayer
{
    [TestClass]
    public class UserBLUnitTests
    {
        private Mock<IUserRepository> userDalRepositoryMock;
        private Mock<IUserMapper> userMapper;
        private IUserBL userBl;
        private User validUser;
        private IQueryable<User> usersList;
        private Mock<TweetsRepository> tweetsRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            tweetsRepositoryMock = new Mock<TweetsRepository>();
            userDalRepositoryMock = new Mock<IUserRepository>();
            userMapper = new Mock<IUserMapper>();
            userBl = new UserBL(userDalRepositoryMock.Object, userMapper.Object);

            validUser = new User
            {
                Id = 1,
                Email = "ion@ion.com",
                Username = "ion",
                Password = "123456",
                FirstName = "Ion",
                LastName = "Vasilescu"
            };
        }

        [TestMethod]
        public void Register_ValidUser_Returns_True()
        {
            bool expected = true;
            bool actual = userBl.Register(validUser);
            Assert.AreEqual(expected, actual, "User successfully registered");
        }

        [TestMethod]

        public void Register_InvalidUserData_Return_false()
        {
            bool expected = false;
            bool actual = userBl.Register(null);
            Assert.AreEqual(actual,expected);
        }

        [TestMethod]
        public void Remove_ValidUser_Returns_True()
        {
            bool expected = true;
            bool actual = userBl.Remove(validUser);
            Assert.AreEqual(expected, actual, "User successfully removed");
        }
        [TestMethod]
        
        public void Remove_InvalidUser_Returns_False()
        {
            bool expected = false;
            bool actual = userBl.Remove(null);
            Assert.AreEqual(expected,actual);
        }
    }
}
