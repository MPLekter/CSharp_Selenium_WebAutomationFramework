using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._1.Utils;
using Task3._1.WebElements;

namespace Task3._1
{
    class RegistrationForm : BaseElement
    {
        DeleteButton deleteButton = new(); //Special button with an index number in locator.
        Button submitButton = new(By.XPath("//button[@id='submit']"), "SubmitButton");
        Input ageInput = new(By.XPath("//input[@id='age']"), "AgeInput");
        Input firstNameInput = new(By.XPath("//input[@id='firstName']"), "FirstNameInput");
        Input lastNameInput = new(By.XPath("//input[@id='lastName']"), "LastNameInput");
        Input userEmailInput = new(By.XPath("//input[@id='userEmail']"), "UserEmailInput");
        Input salaryInput = new(By.XPath("//input[@id='salary']"), "SalaryInput");
        Input departmentInput = new(By.XPath("//input[@id='department']"), "DepartmentInput");

        public RegistrationForm() : base(By.XPath("//form[@id='userForm']"), "RegistrationForm") 
        { }

        public void EnterFirstName(DriverUtility driverUtility, Dictionary<string, string> testData)
        {
            firstNameInput.WaitUntilDisplayed();
            firstNameInput.Click();
            driverUtility.EnterText(testData["UserNo1_FirstName"]);
        }

        public void EnterLastName(DriverUtility driverUtility, Dictionary<string, string> testData)
        {
            lastNameInput.WaitUntilDisplayed();
            lastNameInput.Click();
            driverUtility.EnterText(testData["UserNo1_LastName"]);
        }
        public void EnterEmail(DriverUtility driverUtility, Dictionary<string, string> testData)
        {
            userEmailInput.WaitUntilDisplayed();
            userEmailInput.Click();
            driverUtility.EnterText(testData["UserNo1_Email"]);
        }
        public void EnterAge(DriverUtility driverUtility, Dictionary<string, string> testData)
        {
            ageInput.WaitUntilDisplayed();
            ageInput.Click();
            driverUtility.EnterText(testData["UserNo1_Age"]);
        }
        public void EnterSalary(DriverUtility driverUtility, Dictionary<string, string> testData)
        {
            salaryInput.WaitUntilDisplayed();
            salaryInput.Click();
            driverUtility.EnterText(testData["UserNo1_Salary"]);
        }
        public void EnterDepartment(DriverUtility driverUtility, Dictionary<string, string> testData)
        {
            departmentInput.WaitUntilDisplayed();
            departmentInput.Click();
            driverUtility.EnterText(testData["UserNo1_Department"]);
        }

        public void ClickSubmitButton()
        {
            submitButton.WaitUntilClickable();
            submitButton.Click();
        }

        public void ClickDeleteButtonInChosenRow(int row)
        {
            deleteButton.InsertIndexToLocator(row);
            deleteButton.WaitUntilClickable();
            deleteButton.Click();
        }
    }
}
