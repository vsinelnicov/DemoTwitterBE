using DemoTwitter.DataAccessLayer.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoTwitter.Tests.User.DataAccesLayer
{

    [TestClass]
    public class UserDalUnitTests
    {
        IUserRepository userRepository = new UserRepository();
        private DataAccessLayer.User validUser;
        private DataAccessLayer.User nullUser;

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
            //arrange
            bool expected = true;
            //act
            bool actual = userRepository.Register(validUser);
            //assert
            Assert.AreEqual(expected, actual);
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