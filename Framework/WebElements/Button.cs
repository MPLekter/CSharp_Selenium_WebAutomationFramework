using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.WebElements
{
    public class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name) 
        {
          Locator = locator;
          Name = name;
        }
    }
}
