using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.WebElements;

namespace Task3._1.Pages
{
    class AlertsPage : BaseForm
    {
        Button confirmClickButton = new(By.XPath("//button[@id='confirmButton']"), "ConfirmClickButton");
        Button clickButton = new (By.XPath("//button[@id='alertButton']"), "AlertClickButton");
        Button promptClickButton = new(By.XPath("//button[@id='promtButton']"), "PromptClickButton");

        public AlertsPage() : base(By.XPath("//div[@class='main-header' and contains(text(),'Alerts')]"), "AlertsPage")
        { }

        public void ClickOnClickButton()
        {
            clickButton.WaitUntilClickable();
            clickButton.Click();
        }

        public void ClickOnConfirmClickButton()
        {
            confirmClickButton.WaitUntilClickable();
            confirmClickButton.Click();
        }

        public void ClickOnPromptClickButton()
        {
            promptClickButton.WaitUntilClickable();
            promptClickButton.Click();
        }
    }
}
