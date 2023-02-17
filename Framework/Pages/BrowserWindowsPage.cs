using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.WebElements;

namespace Task3._1.Pages
{
    class BrowserWindowsPage : BaseForm
    {
        Button linksButton = new(By.XPath("//span[text()='Links']"), "LinksButton");
        Button newTabButton = new(By.XPath("//button[@id='tabButton']"), "NewTabButton");
        BaseElement elementsMenu = new(By.XPath("//*[@id='app']/div/div/div[2]/div[1]/div/div/div[1]"), "ElementsMenu");
        public BrowserWindowsPage() : base(By.XPath("//div[@class='main-header' and contains(text(),'Browser Windows')]"), "BrowserWindowsPage")
        { }

        public void ClickNewTabButton()
        {
            newTabButton.WaitUntilClickable();
            newTabButton.Click();
        }

        public void ClickElementsMenu()
        {
            elementsMenu.WaitUntilClickable();
            elementsMenu.Click();
        }

        public void ClickLinksButton()
        {
            linksButton.WaitUntilClickable();
            linksButton.Click();
        }
    }
}
