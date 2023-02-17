using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.Utils
{
    public static class WaitsUtility
    {
        public static WebDriverWait Wait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public static void WaitForVisibleBody(IWebDriver driver)
        {
            Wait(driver).Until(ExpectedConditions.ElementIsVisible(By.TagName("body")));
        }

        public static void WaitForExistingBody(IWebDriver driver)
        {
            Wait(driver).Until(ExpectedConditions.ElementExists(By.TagName("body")));
        }


        public static void WaitUntilClickable(IWebDriver driver, By locator)
        {
            Wait(driver).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitUntilDisplayed(IWebDriver driver, By locator)
        {
            Wait(driver).Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public static void WaitUntilExists(IWebDriver driver, By locator)
        {
            Wait(driver).Until(ExpectedConditions.ElementExists(locator));
        }

        public static void FrameToBeAvailable(IWebDriver driver, By locator)
        {
            Wait(driver).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }
        
        public static IAlert AlertIsPresent(IWebDriver driver)
        {
            return Wait(driver).Until(ExpectedConditions.AlertIsPresent());
        }

        public static bool AlertIsNotPresent(IWebDriver driver) 
        {
            if (Wait(driver).Until(ExpectedConditions.AlertState(false)))
                return true;
            else
            return false;
        }

        public static void NewTabOpened(IWebDriver driver, int currentTabsCount)
        {
            DriverUtility driverUtility = new();
            Wait(driver).Until(driver => driverUtility.GetTabsCount() > currentTabsCount);
        }


    }
}
