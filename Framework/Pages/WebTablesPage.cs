using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.WebElements;

namespace Task3._1.Pages
{
    public class WebTablesPage : BaseForm
    {
        Button addButton = new(By.XPath("//button[@id='addNewRecordButton']"), "AddButton");

        public WebTablesPage() : base(By.XPath("//div[@class='main-header' and contains(text(),'Web Tables')]"), "WebTablesPage")
        { }

        public void ClickAddButton()
        {
            addButton.WaitUntilClickable();
            addButton.Click();
        }
    }
}
