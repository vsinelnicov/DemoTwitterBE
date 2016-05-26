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

namespace DemoTwitter.Tests.TweetAutomationTests
{
    [TestClass]
    public class TweetAutomationTests
    {
       private IWebDriver driver;
       private IWebElement element;
       [TestInitialize]
       public void SetUp()
       {
           driver = new ChromeDriver();
           driver.Navigate().GoToUrl("http://localhost:52316/Home/Login");
           element = driver.FindElement(By.Id("email"));
           element.SendKeys("apapuc30@yahoo.com");
           element = driver.FindElement(By.Id("password"));
           element.SendKeys("alex");
           element = driver.FindElement(By.Id("login-submit"));
           element.Click();
       }

       [TestMethod]
       public void Add_Posting_a_tweet_Returns_true()
       {
           //Arrange
           string expected = "Automation Test!";
           string actual;

           //Act
           element = driver.FindElement(By.Id("post-tweet-input"));
           element.SendKeys("Automation Test!");
           element = driver.FindElement(By.Id("login-submit"));
           element.Click();
           element = driver.FindElement(By.XPath("/html/body/div[2]/ol/li/div[2]"));
           actual = element.Text;

           //Assert
           Assert.AreEqual(actual, expected);

       }

       [TestMethod]
       public void Remove_Removing_a_tweet_Returns_true()
       {
           //Arrange
           string expected;
           string actual;

           //Act
           element = driver.FindElement(By.XPath("/html/body/div[2]/ol/li[1]/div[1]/div[1]"));
           expected = element.Text;
           element = driver.FindElement(By.XPath("/html/body/div[2]/ol/li[1]/div[1]/div[2]/ul/li/a/span"));
           element.Click();
           element = driver.FindElement(By.XPath("/html/body/div[2]/ol/li[1]/div[1]/div[2]/ul/li/ul/li[2]/a"));
           element.Click();
           element = driver.FindElement(By.XPath("/html/body/div[2]/ol/li[1]/div[1]/div[1]"));
           actual = element.Text;

           //Assert
           Assert.AreNotEqual(actual, expected);
       }
       [TestMethod]
       public void Pagination_going_to_second_page_Returns_true()
       {
           //Arrange
           string expected = "http://localhost:52316/User/Index?page=2";
           string actual;

           //Act
           element = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/ul/li[2]/a"));
           element.Click();
           actual = driver.Url;
           //Assert
           Assert.AreEqual(actual, expected);
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
