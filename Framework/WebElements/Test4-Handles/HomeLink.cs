using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.WebElements;

namespace Task3._1
{
    class HomeLink : BaseElement
    {
        public HomeLink() : base(By.XPath("//*[@id='simpleLink']"), "HomeLink") 
        { }
    }
}
