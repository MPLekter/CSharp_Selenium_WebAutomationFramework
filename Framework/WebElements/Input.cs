using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.WebElements
{
    public class Input : BaseElement
    {
        public Input(By locator, string name) : base(locator, name)
        {
            Locator = locator;
            Name = name;
        }

    }
}
