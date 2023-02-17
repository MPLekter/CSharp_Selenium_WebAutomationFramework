using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.WebElements;

namespace Task3._1.Pages
{
    public class MainPage : BaseForm
    {
        Button alertsFrameWindowsButton = new(By.XPath("//*[@id='app']/div/div/div[2]/div/div[3]"), "AlertClickButton");
        Button elementsButton = new(By.XPath("//*[@id='app']/div/div/div[2]/div/div[1]"), "ElementsButton"); //TODO: make a better locator
        public MainPage() : base(By.XPath("//div[@class='category-cards']"), "MainPage")
        { 
        }
        public void ClickAlertsFrameWindowsButton()
        {
            alertsFrameWindowsButton.WaitUntilDisplayed();
            alertsFrameWindowsButton.Click();
        }

        public void ClickElementsButton()
        {
            elementsButton.WaitUntilClickable();
            elementsButton.Click();
        }

    }
}
