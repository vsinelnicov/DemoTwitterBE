using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
        private ModelStateDictionary modelState;
        private IUserBL userBl;
        private User validUser;
        private IQueryable<User> usersList;

        [TestInitialize]
        public void Initialize()
        {
            userDalRepositoryMock = new Mock<IUserRepository>();
            userMapper = new Mock<IUserMapper>();
            modelState = new ModelStateDictionary();
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

            usersList = new List<User>()
            {
                validUser,
                new User
                {
                    Id = 1,
                    Email = "maria@maria.com",
                    Username = "maria",
                    Password = "123456",
                    FirstName = "Maria",
                    LastName = "Vasilescu"
                },
                new User
                {
                    Id = 1,
                    Email = "mihai@mihai.com",
                    Username = "mihai",
                    Password = "123456",
                    FirstName = "Mihai",
                    LastName = "Lupu"
                },
            }.AsQueryable();

            userDalRepositoryMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(usersList.Provider);
            userDalRepositoryMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(usersList.Expression);
            userDalRepositoryMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(usersList.ElementType);
            userDalRepositoryMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(usersList.GetEnumerator());

        }

        [TestMethod]
        public void Register_ValidUser_Returns_True()
        {
            bool expected = true;
            bool actual = userBl.Register(validUser);
            Assert.AreEqual(expected, actual, "User successfully registered");
        }

        [TestMethod]
        public void Register_InvalidUserData_Returns_False()
        {
            bool expected = false;
            bool actual = userBl.Register(null);
            Assert.AreEqual(expected, actual, "Invalid user data entered");
        }

        //[TestMethod]
        //public void GetByEmail_GetsTheUserWithTheSpecifiedEmail()
        //{
        //    string expectedEmail = "ion@ion.com";
        //    User expected = new User { Email = expectedEmail };
        //    //var mockSet = new Mock<User>();
            
        //    //userDalRepositoryMock.Setup(x => x.GetByEmail(expectedEmail)).Returns(userMapper.Object.MapToDatabaseType(mockSet.Object));
        //    //userMapper.Setup(m=>m.MapToUserModel())
        //    User actual = userMapper.Object.MapToUserModel(userDalRepositoryMock.Object.GetByEmail(expectedEmail));

        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual(expected.Email, actual.Email);
        //}

    }
}
