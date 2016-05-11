using DemoTwitter.DataAccessLayer.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoTwitter.Tests.User.DataAccesLayer
{

    [TestClass]
    public class UserDalUnitTests
    {
        IUserRepository userRepository = new UserRepository();

        [TestMethod]
        public void Register_ValidUserAdded_ReturnsTrue()
        {
            //arrange
            var user = new DataAccessLayer.User
            {
                username = "ion",
                email = "ion@ion.com",
                firstname = "Ion",
                lastname = "Popescu",
                password = "123456"
            };
            bool expected = true;
            //act
            bool actual = userRepository.Register(user);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Register_NullUserAdded_ReturnsFalse()
        {
            var user = new DataAccessLayer.User();
            user = null;
            bool expected = false;

            bool actual = userRepository.Register(user);

            Assert.AreEqual(expected, actual);
        }
    }
}