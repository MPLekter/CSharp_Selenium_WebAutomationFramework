using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.Utils;

namespace Task3._1.WebElements
{
    public class BaseElement 
    {
        public IWebDriver driver;
        public By Locator { get; set; }
        public string Name { get; set; }

        public BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name;
            driver = Singleton.Driver();
        }
        public void Click()
        {
            try
            {
                GetElement().Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while trying to click. Trying javascript click to avoid {ex.Message}");
                IJavaScriptExecutor jSE = (IJavaScriptExecutor)driver;
                jSE.ExecuteScript("arguments[0].click();", driver.FindElement(Locator));
            }
        }
        public IWebElement GetElement()
        {
            return driver.FindElement(Locator);
        }
        public string GetText()
        {
            return GetElement().Text;
        }

        public bool IsDisplayed()
        {
            return GetElement().Displayed;
        }

        public void WaitUntilDisplayed()
        {
            WaitsUtility.WaitUntilDisplayed(driver, Locator);
        }
        public void WaitUntilExists()
        {
            WaitsUtility.WaitUntilExists(driver, Locator);
        }
        public void WaitUntilClickable()
        {
            WaitsUtility.WaitUntilClickable(driver, Locator);
        }

    }
}
