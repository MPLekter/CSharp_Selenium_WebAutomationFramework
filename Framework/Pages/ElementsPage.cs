using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.WebElements;

namespace Task3._1.Pages
{
    class ElementsPage : BaseForm
    {
        Button webTablesButton = new(By.XPath("//span[text()='Web Tables']"), "WebTablesButton");
        public ElementsPage() : base(By.XPath("//div[@class='main-header' and contains(text(),'Elements')]"), "ElementsPage")
        { }

        public void ClickWebTablesButton()
        {
            webTablesButton.WaitUntilClickable();
            webTablesButton.Click();
        }
    }
}
