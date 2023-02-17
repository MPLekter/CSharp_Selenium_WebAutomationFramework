using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.WebElements;

namespace Task3._1
{
    class DeleteButton : BaseElement
    {

        public DeleteButton() : base(By.XPath("//span[@id='delete-record-']"), "DeleteButton")
        { }
        public int index
        {
            get; set;
        }

        public void InsertIndexToLocator(int index)
        {
            Locator = By.XPath($"//span[@id='delete-record-{index}']");
        }
    
    }


    
}
