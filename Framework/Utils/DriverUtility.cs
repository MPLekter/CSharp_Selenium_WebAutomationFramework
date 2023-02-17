using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.Utils
{
    public class DriverUtility
    {
        public IWebDriver driver = Singleton.Driver();
        private Actions actions = new Actions(Singleton.Driver());

        public string GetCurrentURL()
        {
            return driver.Url;
        }

        public string GetCurrentWindowHandle()
        {
            return driver.CurrentWindowHandle;
        }

        public void CloseCurrentTab() //TODO: check if works
        {
            driver.Close();
        }

        public void SwitchToMainTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
        public void Firefox_SwitchToNextTab()
        {
            string currentWindow = GetCurrentWindowHandle();
            //int currentIndex = driver.WindowHandles[currentWindow]; //.FirstOrDefault();? //TODO: how to find current windows' index in windowhandles?
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        public void SwitchToNextTab()
        {
            string originalWindow = GetCurrentWindowHandle();

            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public int GetTabsCount()
        {
            return driver.WindowHandles.Count;
        }

        public void ScrollToElement(IWebElement element)
        {
            actions.MoveToElement(element).Perform();
        }

        public static IReadOnlyCollection<IWebElement> GetChildren(IWebElement parent)
        {
            return parent.FindElements(By.XPath("./child::*"));
        }

        public void EnterText(string keys)
        {
            actions.SendKeys(keys).Perform();
        }
    }
}
