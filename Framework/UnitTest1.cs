using OpenQA.Selenium;
using Task3._1.Pages;
using Task3._1.WebElements;
using Task3._1.Utils;
using OpenQA.Selenium.Interactions;
using Newtonsoft.Json;
using OpenQA.Selenium.DevTools;
using System.Xml.Linq;
using log4net;
using log4net.Config;
using System.Linq;

namespace Task3._1
{
    [TestFixture]
    public class Tests

    {
        #region NOTES
        //TODO: Get rid of this once all tests and requirements are done
        /*REQS:
        BaseForm class (v) 
        BaseElement class and child classes for elements (v) 
        Singleton & BrowserFactory (Factory method) to organize process of getting driver instance (v)
        Utility class to work with driver (v) 
        ConfigManager class (v) 
        Tests should be working on Chrome and Firefox browsers (v) 
        There should be an option to choose browser --> Where? Answer from Alex: PUT IN JSON FILE IN CONFIG. (v) 
        PageObject pattern should be used (v) 
        Pre and post conditions should be used (x TODO: fix bugs that come with driver.Quit() enabled) 
        Logger should be used (v) TODO: ask about other requirements for logger other than its existence
        ONE of the tests should be using DDT approach and be parametrized (Data-Driven Testing: test out-in-put data is separated from the actual test case) (v)
        Test data and config data to be stored in separate files (v) 
        Solution structure should be organized into different folders, namespaces, packages and clear which class goes where (v) 
        */
        #endregion


        IWebDriver driver;  
        DriverUtility driverUtility;
        ConfigManager configManager;
        ILog log;

        [SetUp]
        public void Setup()
        {
            configManager = new ConfigManager();
            ConfigManager.ChooseBrowser(); 
            configManager.ChooseUrl();

            //TODO: move log related things into Logger class
            BasicConfigurator.Configure();

            driverUtility = new DriverUtility();

            driver = Singleton.Driver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConfigManager.Url);
        }

        [Test]
        public void Alerts()
        {
            log = LogManager.GetLogger(nameof(Alerts));
            log.Info("Started the test");

            var testData = configManager.PrepareAlertsTestData();
            log.Info("Data loaded");

            //S1 Navigate to main page
            MainPage mainPage = new();
            mainPage.WaitForOpen();
            //A1 Main page is open
            Assert.That(mainPage.IsDisplayed(), $"{nameof(mainPage)} did not display");
            log.Info("A1 correct");
            //S2 Click on Alerts, Frame & Windows button. In a menu click Alerts button.
            mainPage.ClickAlertsFrameWindowsButton();
            AlertsFrameWindowsPage alertsFrameWindowsPage = new();
            alertsFrameWindowsPage.WaitForOpen();
            //alertsFrameWindowsPage.ClickAlertsFrameWindowsMenu(); //turning this off to see if it resolves a bug
            alertsFrameWindowsPage.ClickAlertsButton();
            //A2 Alerts form has appeared on page
            AlertsPage alertsPage = new(); 
            alertsPage.WaitForOpen();
            BaseElement alertsForm = new(By.XPath("//*[@id='javascriptAlertsWrapper']"), "AlertsForm");
            alertsForm.WaitUntilDisplayed();
            Assert.That(alertsForm.IsDisplayed(), $"{nameof(alertsForm)} did not display");
            log.Info("A2 correct");
            //S3 Click on Click Button to see alert button
            alertsPage.ClickOnClickButton();
            //A3 Alert with text "You clicked a button" is open
            IAlert alert = WaitsUtility.AlertIsPresent(driver); //TODO: ask if alert should be moved out of here?
            Assert.That(alert.Text, Is.EqualTo(testData["Assertion3"]), "Incorrect alert text");
            log.Info("A3 correct");
            //S4 Click OK button
            alert.Accept();
            //A4 Alert has closed
            Assert.True(WaitsUtility.AlertIsNotPresent(driver), "Alert is still open");
            log.Info("A4 correct");
            //S5 Click on button click, confirm box will appear button
            alertsPage.ClickOnConfirmClickButton();
            //A5 Alert with text "Do you confirm action?" is opened
            alert = WaitsUtility.AlertIsPresent(driver); //TODO: ask if alert should be moved out of here?
            Assert.That(alert.Text, Is.EqualTo(testData["Assertion5"]), "Incorrect alert text");
            log.Info("A5 correct");
            //S6 Click OK button
            alert.Accept();
            //A6 Alert has closed. 
            Assert.True(WaitsUtility.AlertIsNotPresent(driver), "Alert is still open");
            log.Info("A6 correct");
            //A6.1 Text "You selected Ok" has appeared on page
            BaseElement confirmResult = new(By.XPath("//span[@id='confirmResult']"), "ConfirmResult");
            confirmResult.WaitUntilDisplayed();
            Assert.That(confirmResult.GetText(), Is.EqualTo(testData["Assertion6.1"]), "Incorrect confirm result text");
            log.Info("A6.1 correct");
            //S7 Click on On button click, prompt box will appear button
            alertsPage.ClickOnPromptClickButton();
            //A7 Alert with text "Please enter your name" is open
            alert = WaitsUtility.AlertIsPresent(driver); //TODO: ask if alert should be moved out of here?
            Assert.That(alert.Text, Is.EqualTo(testData["Assertion7"]), "Incorrect alert text");
            log.Info("A7 correct");
            //S8 Enter randomly generated text, click OK button
            string rgt = RandomStringGenerator.RandomString(); 
            alert.SendKeys(rgt);
            alert.Accept();
            //A8 Alert has closed. 
            Assert.True(WaitsUtility.AlertIsNotPresent(driver), "Alert is still open");
            log.Info("A8 correct");
            //A8.1 Appeared text equals to the one you've entered before.
            BaseElement promptResult = new(By.XPath("//*[@id='promptResult']"), "PromptResult");  
            promptResult.WaitUntilDisplayed();
            Assert.That(promptResult.GetText(), Is.EqualTo(testData["Assertion8.1"] + rgt), "Incorrect prompt result text");
            log.Info("A8.1 correct");
        }

        [Test]
        public void Iframe()
        {
            //S1 Navigate to main page
            MainPage mainPage = new();
            mainPage.WaitForOpen();
            //A1 Main page is open
            Assert.That(mainPage.IsDisplayed(), $"{nameof(mainPage)} did not display");
            //S2 Click on Alerts, Frame & Windows button. In a menu click Nested Frames button.
            mainPage.ClickAlertsFrameWindowsButton();
            AlertsFrameWindowsPage alertsFrameWindowsPage = new();
            alertsFrameWindowsPage.WaitForOpen();
            alertsFrameWindowsPage.ClickNestedFramesButton();
            //A2 Page with Nested Frames is open
            NestedFramesPage nestedFramesPage = new();
            nestedFramesPage.WaitForOpen();
            Assert.That(nestedFramesPage.IsDisplayed(), $"{nameof(nestedFramesPage)} did not display");
            //A3 There are messages "Parent frame" & "Child Iframe" present on page
            IWebElement frame1 = driver.FindElement(By.Id("frame1")); //TODO: ask if frames should be here?
            driver.SwitchTo().Frame(frame1);
            IWebElement frame1message = driver.FindElement(By.XPath("/html/body"));
            string f1mt = frame1message.Text;
            //var childFrames = frame1.FindElements(By.XPath("./child::*")); //Bugged
            //IWebElement frame2 = childFrames.FirstOrDefault<IWebElement>();  // /html/body/iframe
            IWebElement frame2 = driver.FindElement(By.XPath("//*[srcdoc='<p>Child frame</p>']")); //Bugged // /html/body/iframe <- worked but stopped.
            driver.SwitchTo().Frame(frame2);
            IWebElement frame2message = driver.FindElement(By.XPath("/html/body"));
            string f2mt = frame2message.Text;
            Assert.That(f1mt == "Parent frame", "message is incorrect or not present"); //TODO: ask if this needs to be one assertion?
            Assert.That(f2mt == "Child Iframe", "message is incorrect or not present");
            //S4 Select Frames option in a left menu
            driver.SwitchTo().DefaultContent();
            nestedFramesPage.ClickFramesButton();
            //A4 Page with Frames form is open
            FramesPage framesPage = new();
            framesPage.WaitForOpen();
            Assert.That(framesPage.IsDisplayed(), $"{nameof(framesPage)} did not display");
            //A5 Message from upper frame is equal to the message from lower frame
            frame1 = driver.FindElement(By.Id("frame1"));
            driver.SwitchTo().Frame(frame1); 
            frame1message = driver.FindElement(By.XPath("//*[@id='sampleHeading']")); //TODO: the test worked for 2 days but now stopped. Try add more wait here?.
            f1mt = frame1message.Text;

            driver.SwitchTo().DefaultContent();

            frame2 = driver.FindElement(By.Id("frame2"));
            driver.SwitchTo().Frame(frame2);
            frame2message = driver.FindElement(By.XPath("//*[@id='sampleHeading']"));
            f2mt = frame2message.Text;

            Assert.That(f1mt == f2mt, "upper frame message is not equal to lower frame message");
        }
        
        [Test]
        public void Tables()
        {
            var testData = configManager.PrepareTablesTestData();

            //S1 Navigate to main page
            MainPage mainPage = new();
            mainPage.WaitForOpen();
            //A1 Main page is open
            Assert.That(mainPage.IsDisplayed(), $"{nameof(mainPage)} did not display");
            //S2 Click on Elements button, In the menu click Web tables button
            mainPage.ClickElementsButton();
            ElementsPage elementsPage = new();
            elementsPage.WaitForOpen();
            elementsPage.ClickWebTablesButton();
            //A2 Page with Web Tables form is open
            WebTablesPage webTablesPage = new();    
            webTablesPage.WaitForOpen();
            Assert.That(webTablesPage.IsDisplayed(), $"{nameof(webTablesPage)} did not display");

            //TODO: think about this way of caching a number of data rows in the beginning. Is it robust?
            IReadOnlyCollection<IWebElement> previousRowsWithData = driver.FindElements(By.XPath("//div[@class='action-buttons']"));

            //S3 Click on Add button 
            webTablesPage.ClickAddButton();
            //A3 Registration Form has appeared on page
            RegistrationForm registrationForm = new();
            registrationForm.WaitUntilDisplayed();
            Assert.That(registrationForm.IsDisplayed(), $"{nameof(registrationForm)} did not display");
            //S4 Enter data for User No from the table and then click Submit button
            //TODO: make a loop that iterates over every input and fills it with input data.
            registrationForm.EnterFirstName(driverUtility, testData);
            registrationForm.EnterLastName(driverUtility, testData);
            registrationForm.EnterEmail(driverUtility, testData);
            registrationForm.EnterAge(driverUtility, testData);
            registrationForm.EnterSalary(driverUtility, testData);
            registrationForm.EnterDepartment(driverUtility, testData);
            registrationForm.ClickSubmitButton();
            //A4 Registration form has closed
            Assert.That(webTablesPage.IsDisplayed(), $"{nameof(webTablesPage)} did not display");
            //A5 Data of User No has appeared in a table
            IReadOnlyCollection<IWebElement> currentRowsWithData = driver.FindElements(By.XPath("//div[@class='action-buttons']"));
            Assert.That(previousRowsWithData.Count != currentRowsWithData.Count, $"The data in table did not change. There are {currentRowsWithData.Count} rows of data");
            //S5 Click Delete button in a row which contains data of User No
            registrationForm.ClickDeleteButtonInChosenRow(currentRowsWithData.Count);
            //A6 Number of records in table has changed
            previousRowsWithData = currentRowsWithData;
            currentRowsWithData = driver.FindElements(By.XPath("//div[@class='action-buttons']"));
            Assert.That(previousRowsWithData.Count != currentRowsWithData.Count, $"The data in table did not change. There are {currentRowsWithData.Count} rows of data");
            //A7 Data of User No has been deleted from table
            Assert.That(previousRowsWithData.Count != currentRowsWithData.Count, $"The data in table did not change. There are {currentRowsWithData.Count} rows of data"); //TODO: ask about writing this assertion in a better way

            driver.Quit();
        }

        [Test]
        public void Handles()
        {
            //S1 Navigate to main page
            MainPage mainPage = new();
            mainPage.WaitForOpen();
            //A1 Main page is open
            Assert.That(mainPage.IsDisplayed(), $"{nameof(mainPage)} did not display");
            //S2 Click on Alerts, Frame & Windows button. In the menu click a Browser Windows Button
            mainPage.ClickAlertsFrameWindowsButton();
            AlertsFrameWindowsPage alertsFrameWindowsPage = new();
            alertsFrameWindowsPage.WaitForOpen();
            alertsFrameWindowsPage.ClickBrowserWindowsButton();
            //A2 Page with Browser Windows form is open
            BrowserWindowsPage browserWindowsPage = new();
            browserWindowsPage.WaitForOpen();
            Assert.That(browserWindowsPage.IsDisplayed(), $"{nameof(browserWindowsPage)} did not display");
            //S3 Click on New Tab button
            browserWindowsPage.ClickNewTabButton();
            //A3 New tab with sample page is open
            //WaitsUtility.NewTabOpened(driver, driverUtility.GetTabsCount()); //BUG: this times out. TODO: check it!
            string driverType = ConfigManager.DriverType;
            if (driverType == "ChromeDriver")
            {
                driverUtility.SwitchToNextTab();
            }
            else if (driverType == "FirefoxDriver")
            {
                driverUtility.Firefox_SwitchToNextTab();
            }
            Assert.That(driver.Url == "https://demoqa.com/sample", "tab had not been opened or switched to"); //TODO: ask about it, maybe change this assertion to standard IsDisplayed
            //S4 Close current tab
            driverUtility.CloseCurrentTab();
            //A4 Page with Browser Windows form is open
            driverUtility.SwitchToMainTab();
            browserWindowsPage = new BrowserWindowsPage();
            browserWindowsPage.WaitForOpen();
            Assert.That(browserWindowsPage.IsDisplayed(), $"{nameof(browserWindowsPage)} did not display");
            //S5 In the menu on the left click Elements -> Links button
            browserWindowsPage.ClickElementsMenu();
            browserWindowsPage.ClickLinksButton();
            //A5 Page with Links form is open
            LinksPage linksPage = new();
            linksPage.WaitForOpen();
            Assert.That(linksPage.IsDisplayed(), $"{nameof(linksPage)} did not display");
            //S6 Click on Home link 
            linksPage.ClickHomeLink();
            //A6 New tab with main page is open
            if (driverType == "ChromeDriver")
            {
                driverUtility.SwitchToNextTab();
            }
            else if (driverType == "FirefoxDriver")
            {
                driverUtility.Firefox_SwitchToNextTab();
                WaitsUtility.WaitUntilExists(driver, By.XPath("//div[@class='category-cards']")); //TODO: think about it. It's main page. Why is it needed?
            }

            mainPage = new MainPage();
            mainPage.WaitForOpen();
            // Console.WriteLine(driver.Url); //returns about:blank if windowHandles[1]. returns links if windowHandles[0]
            Assert.That(mainPage.IsDisplayed(), $"{nameof(mainPage)} did not display"); 
            //S7 Resume to previous tab
            driverUtility.SwitchToNextTab(); //TODO: in this case (2 tabs) it works. But think about 3 tabs or so. You need a dedicated method.
            //A7 Page with Links form is open
            linksPage = new LinksPage();
            linksPage.WaitForOpen();
            Assert.That(linksPage.IsDisplayed(), $"{nameof(linksPage)} did not display");
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit(); //DON'T do it. Will give the object disposed exception. 
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}

