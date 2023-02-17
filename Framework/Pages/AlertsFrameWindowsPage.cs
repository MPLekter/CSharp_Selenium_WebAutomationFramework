using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.Utils;
using Task3._1.WebElements;

namespace Task3._1.Pages
{
    class AlertsFrameWindowsPage : BaseForm
    {
        Button alertsFrameWindowsMenu = new(By.XPath("//*[@id='app']/div/div/div[2]/div[1]/div/div/div[3]"), "AlertsFrameWindowsMenu");
        Button alertsButton = new(By.XPath("//span[text()='Alerts']"), "AlertsButton");
        Button nestedFramesButton = new(By.XPath("//span[text()='Nested Frames']"), "NestedFramesButton");
        Button browserWindowsButton = new(By.XPath("//span[text()='Browser Windows']"), "BrowserWindowsButton");
        public AlertsFrameWindowsPage() : base(By.XPath("//div[@class='main-header' and contains(text(),'Alerts, Frame & Windows')]"), "AlertsFrameWindowsPage")
        { }

        public void ClickAlertsFrameWindowsMenu()
        {
            alertsFrameWindowsMenu.WaitUntilDisplayed();
            alertsFrameWindowsMenu.Click();
        }

        public void ClickAlertsButton()
        {
            alertsButton.WaitUntilClickable();
            alertsButton.Click();
        }

        public void ClickNestedFramesButton()
        {
            nestedFramesButton.WaitUntilClickable();
            nestedFramesButton.Click();
        }

        public void ClickBrowserWindowsButton()
        {
            browserWindowsButton.WaitUntilClickable();
            browserWindowsButton.Click();
        }
    }
}
