using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.Utils
{
    public class Singleton
    {
        static IWebDriver driver;

        public static IWebDriver Driver()
        {
            if (driver == null)
            {
                driver = BrowserFactory.InitDriver();
            }
            return driver;
        }
    }
}
