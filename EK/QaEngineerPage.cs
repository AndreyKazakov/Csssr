using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Csssr
{
    class QaEngineerPage
    {
        public QaEngineerPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section[1]/section/div[2]/a")]                     
        public IWebElement lnkSecondTab { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section[2]/div[2]/aside/ul/li[4]/label/a")]
        public IWebElement lnkToMonosnap { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section[2]/div[2]/h1")]
        public IWebElement txtHeaderOnSecondTab { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section[2]/div[2]")]
        public IWebElement txtDivOfSecondTab { get; set; }


    }
}
