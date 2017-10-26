using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Csssr
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        [SetUp]
        public void Initialize()
        {                                              
            PropertiesCollection.driver = new ChromeDriver();                       
        }

        [Test]
        public void CheckLinkToSoftForScreenshots()
        {
            PropertiesCollection.driver.Navigate().GoToUrl("http://blog.csssr.ru/qa-engineer/");
            PropertiesCollection.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1000);

            QaEngineerPage page = new QaEngineerPage();
            page.lnkSecondTab.Clicks();
            page.lnkToMonosnap.Clicks();
            PropertiesCollection.driver.Close();
            PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles.Last());

            Console.WriteLine(PropertiesCollection.driver.Url);
            Assert.IsTrue(PropertiesCollection.driver.Url.Contains("monosnap.com"), "Error: redirect to monosnap.com is unsuccessful");             

        }

        [Test]
        public void ClickingOnSameTabTwoTimes()
        { 
            PropertiesCollection.driver.Navigate().GoToUrl("http://blog.csssr.ru/qa-engineer/");
            
            QaEngineerPage page = new QaEngineerPage();
            page.lnkSecondTab.Clicks();            
            Assert.IsTrue(page.txtDivOfSecondTab.GetAttribute("style").Contains("display: block"));
            
            page.lnkSecondTab.Clicks();
            Thread.Sleep(1800);            
            Assert.IsTrue(page.txtDivOfSecondTab.GetAttribute("style").Contains("display: block"), 
                "Error: Content of block is not shown. Style = "+ page.txtDivOfSecondTab.GetAttribute("style"));
        }

        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
        }
    }


}
