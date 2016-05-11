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
