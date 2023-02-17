using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.Utils;

namespace Task3._1.Pages
{
    public class BaseForm 
    {
        public IWebDriver driver;
        public By Locator { get; }
        public string Name { get; }

        public BaseForm(By locator, string name)
        {
            Locator = locator;
            Name = name;
            driver = Singleton.Driver();
        }
        public void WaitForOpen()
        {
            WaitsUtility.WaitForVisibleBody(driver);
        }

        public bool IsDisplayed()
        {
            return driver.FindElement(Locator).Displayed;
        }
    }
}
