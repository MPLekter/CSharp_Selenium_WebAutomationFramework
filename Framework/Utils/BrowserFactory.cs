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
    public static class BrowserFactory
    {
        private static IWebDriver driver;
        public static IWebDriver InitDriver()
        {
            ConfigManager.ChooseBrowser();

            switch (ConfigManager.DriverType)
            {
                case "ChromeDriver": driver = new ChromeDriver(); break;
                case "FirefoxDriver": driver = new FirefoxDriver(); break;
            }

            return driver;
        }
    }
}
