using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.Pages
{
    class LinksPage : BaseForm
    {
        public LinksPage() : base(By.XPath("//div[@class='main-header' and contains(text(),'Links')]"), "LinksPage")
        { }

        public void ClickHomeLink()
        {
            HomeLink homeLink = new();
            homeLink.WaitUntilClickable();
            homeLink.Click();
        }
    }
}
