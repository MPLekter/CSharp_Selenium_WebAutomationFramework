using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.Pages
{
    class FramesPage : BaseForm
    {
        //loc By.XPath("//div[@class='main-header' and contains(text(),'Frames')]");
        //name "FramesPage"
        public FramesPage() : base(By.XPath("//div[@class='main-header' and contains(text(),'Frames')]"), "FramesPage")
        {

        }
    }
}
