
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TwitterAutomationTets
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:52316/");
            IWebElement element = driver.FindElement(By.Id("email"));
            element.SendKeys("apapuc@gmail.com");
        }
    }
}
