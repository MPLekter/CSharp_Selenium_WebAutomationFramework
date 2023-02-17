using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.WebElements;

namespace Task3._1.Pages
{
    class NestedFramesPage : BaseForm
    {
        Button framesButton = new(By.XPath("//span[text()='Frames']"), "FramesButton");
        public NestedFramesPage() : base(By.XPath("//div[@class='main-header' and contains(text(),'Nested Frames')]"), "NestedFramesPage")
        {
        }

        public void ClickFramesButton()
        {
            framesButton.WaitUntilClickable();
            framesButton.Click();
        }
    }
}
