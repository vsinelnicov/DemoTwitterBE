using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTwitter.DataAccessLayer
{
    [TestClass]
    public class UserDalUnitTests
    {
        private User validUser;
        private User nullUser;
        private IQueryable<User> usersListForTest;
        private Mock<DbSet<User>> mockSet;
        private Mock<Twitter_dbEntities> mockContext;
        private UserRepository repository;

        [TestInitialize]
        public void Initialization()
        {
            mockSet = new Mock<DbSet<User>>();
            mockContext = new Mock<Twitter_dbEntities>();
            repository = new UserRepository(mockContext.Object);
            nullUser = null;

            validUser = new User
            {
                id = 1,
                email = "ion@ion.com",
                username = "ion",
                firstname = "Ion",
                lastname = "Popescu",
                password = "123456"
            };

            usersListForTest = new List<User>(){ 
                validUser,
                new User
            {
                id = 2,
                email = "vasile@vasile.ro",
                username = "vasile",
                firstname = "vasile",
                lastname = "moraru",
                password = "123456"
            },
                new User
            {
                id = 2,
                email = "maria@maria.ro",
                username = "marymary",
                firstname = "maria",
                lastname = "ionesco",
                password = "123456"
            } 
            }.AsQueryable();

            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(usersListForTest.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(usersListForTest.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(usersListForTest.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(usersListForTest.GetEnumerator());
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        }

        [TestMethod]
        public void Register_Saves_a_User_via_Context()
        {

            repository.Register(validUser);
            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Register_NullUserAdded_Returns_False()
        {
            bool expected = false;
            bool actual = repository.Register(nullUser);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByEmail_GetsTheUserWithTheSpecifiedEmail()
        {
            string expectedEmail = "ion@ion.com";
            User expected = new User { email = expectedEmail };
            var actual = repository.GetByEmail(expectedEmail);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.email, actual.email);
        }

        [TestMethod]
        public void GetByUsername_GetsTheUserWithTheSpecifiedUsername()
        {
            string expectedUsername = "ion";
            User expected = new User { username = expectedUsername };
            var actual = repository.GetByUsername(expectedUsername);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.username, actual.username);
        }

        [TestMethod]
        public void GetAll_GetsAllUserFromDatabase()
        {
            mockSet.Setup(u => u.Add(validUser));
            var actual = repository.GetAll();
            Assert.AreEqual(3, actual.Count);
        }

        [TestMethod]
        public void Remove_RemoveValidUserFromDatabase_Returns_True()
        {
            bool actual = repository.Remove(validUser);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Remove_RemoveInvalidUserFromDatabase_Returns_False()
        {
            bool actual = repository.Remove(nullUser);

            Assert.AreEqual(false, actual);
        }
    }
}