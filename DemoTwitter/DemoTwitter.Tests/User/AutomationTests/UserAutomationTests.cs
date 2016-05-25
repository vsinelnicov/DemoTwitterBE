using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoTwitter.Tests.UserAutomationTests
{
    [TestClass]
    public class UserAutomationTests
    {
        private IWebDriver driver;
        private IWebElement element;
        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();

        }

        [TestMethod]
        public void Accessing_twitter_first_page()
        {
            //Arrange

            string actual;
            string expected = "http://localhost:52316/Home/Login";

            //Act
            driver.Navigate().GoToUrl("http://localhost:52316/Home/Login");
            actual = driver.Url;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Login_into_twitter_with_an_existing_account()
        {
            //Arrange 
            string actual;
            string expected = "http://localhost:52316/User/Index";

            //Act
            driver.Navigate().GoToUrl("http://localhost:52316/Home/Login");
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("apapuc30@yahoo.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("alex");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();

            actual = driver.Url;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Login_into_twitter_with_an_unexisting_account()
        {
            //Arrange 
            string actual;
            string expected = "http://localhost:52316/";

            //Act
            driver.Navigate().GoToUrl("http://localhost:52316/");
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("apappucusc@gmail.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("nopasword");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();

            actual = driver.Url;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Register_Into_Twitter_and_log_in_with_registered_account_Delete_created_account()
        {
            //Arrange
            string actual;
            string expected1 = "http://localhost:52316/User/Index";
            string expected2 = "http://localhost:52316/";

            driver.Navigate().GoToUrl("http://localhost:52316/Home/Register");
            element = driver.FindElement(By.Id("username"));
            element.SendKeys("eugen");
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("eugen@mail.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("eugen");
            element = driver.FindElement(By.Id("lastname"));
            element.SendKeys("Eugen");
            element = driver.FindElement(By.Id("firstname"));
            element.SendKeys("Papuc");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();

            element = driver.FindElement(By.Id("email"));
            element.SendKeys("eugen@mail.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("eugen");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();
            actual = driver.Url;
            Assert.AreEqual(expected1, actual);
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[2]/li[1]/a"));
            element.Click();
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[2]/li[1]/ul/li[2]/a"));
            element.Click();
            actual = driver.Url;
            //Assect
            Assert.AreEqual(expected2, actual);
        }
        [TestMethod]
        public void Going_to_feed_page()
        {
            //Arrange
            string actual;
            string expected = "http://localhost:52316/Tweet/FollowedUsersFeed";

            //Act

            driver.Navigate().GoToUrl("http://localhost:52316/Home/Login");
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("apapuc30@yahoo.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("alex");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[1]/li[3]/a"));
            element.Click();
            actual = driver.Url;

            //Assect
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Going_to_All_users_page()
        {
            //Arrange
            string actual;
            string expected = "http://localhost:52316/User/All";

            //Act

            driver.Navigate().GoToUrl("http://localhost:52316/Home/Login");
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("apapuc30@yahoo.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("alex");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[1]/li[2]/a"));
            element.Click();
            actual = driver.Url;

            //Assect
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Checking_follow_functionality()
        {
            //Arrange
            string actual;
            string expected;

            //Act
            driver.Navigate().GoToUrl("http://localhost:52316/Home/Login");
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("apapuc30@yahoo.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("alex");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[1]/li[3]/a"));
            element.Click();
            element = driver.FindElement(By.XPath("/html/body/div/ol/li/div[2]"));
            actual = element.Text;
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[1]/li[2]/a"));
            element.Click();
            element = driver.FindElement(By.XPath("/html/body/div/table/tbody/tr[3]/td[4]/a"));
            element.Click();
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[1]/li[3]/a"));
            element.Click();
            element = driver.FindElement(By.XPath("/html/body/div/ol/li/div[2]"));
            expected = element.Text;

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void Edit_user_profile_check()
        {
            //Arrange

            string actual;
            string expected = "http://localhost:52316/User/Edit";

            //Act

            driver.Navigate().GoToUrl("http://localhost:52316/Home/Login");
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("apapuc30@yahoo.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("alex");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[2]/li[1]/a"));
            element.Click();
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[2]/li[1]/ul/li[1]/a"));
            element.Click();
            actual = driver.Url;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Logout_from_twitter()
        {
            //Arrange

            string actual;
            string expected = "http://localhost:52316/";

            //Act

            driver.Navigate().GoToUrl("http://localhost:52316/Home/Login");
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("apapuc30@yahoo.com");
            element = driver.FindElement(By.Id("password"));
            element.SendKeys("alex");
            element = driver.FindElement(By.Id("login-submit"));
            element.Click();
            element = driver.FindElement(By.XPath("id('myNavbar')/ul[2]/li[2]/a"));
            element.Click();
            actual = driver.Url;

            //Assert

            Assert.AreEqual(expected, actual);
        }
        [TestCleanup]
        public void CleanUp()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Dispose();
            }
        }

    }
}
