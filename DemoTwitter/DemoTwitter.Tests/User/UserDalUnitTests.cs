using System;
using System.Collections.Generic;
using System.Data.Entity;
using DemoTwitter.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTwitter.Tests.User.DataAccesLayer
{

    [TestClass]
    public class UserDalUnitTests
    {
        private readonly IUserRepository userRepository;
        private DataAccessLayer.User validUser;
        private DataAccessLayer.User nullUser;



        public UserDalUnitTests(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserDalUnitTests()
        {
        }

        [TestInitialize]
        public void Initialization()
        {
            validUser = new DataAccessLayer.User
            {
                username = "ion",
                email = "ion@ion.com",
                firstname = "Ion",
                lastname = "Popescu",
                password = "123456"
            };

            nullUser = null;
        }

        [TestMethod]
        public void Register_ValidUserAdded_ReturnsTrue()
        {
            var mockSet = new Mock<DbSet<DataAccessLayer.User>>();
            var mockContext = new Mock<Twitter_dbEntities>();

            mockContext.Setup(u => u.Users).Returns(mockSet.Object);

            var repository = new UserRepository(mockContext.Object);

            const bool expected = true;
            bool actual = repository.Register(validUser);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Register_ValidUser_ReturnsTrue()
        {
            var mockSet = new Mock<DbSet<DataAccessLayer.User>>();
            var mockContext = new Mock<Twitter_dbEntities>();

            var repository = new UserRepository(mockContext.Object);
            repository.Register(validUser);

            mockSet.Verify(m => m.Add(It.IsAny<DataAccessLayer.User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Register_NullUserAdded_ReturnsFalse()
        {
            bool expected = false;

            bool actual = userRepository.Register(nullUser);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Update_NullUser_ReturnsFalse()
        {

        }

        [TestCleanup]
        public void Clear()
        {

        }
    }
}