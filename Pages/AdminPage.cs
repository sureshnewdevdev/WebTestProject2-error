using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRMSAutomation.Pages
{
    public class AdminPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        private IWebElement AdminMenu =>
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']")));

        private IWebElement AddButton =>
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='Add']")));

        private IWebElement EmployeeName =>
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Type for hints...']")));

        private IWebElement Username =>
            driver.FindElement(By.XPath("(//input[@class='oxd-input oxd-input--active'])[2]"));

        private IWebElement Password =>
            driver.FindElement(By.XPath("(//input[@type='password'])[1]"));

        private IWebElement ConfirmPassword =>
            driver.FindElement(By.XPath("(//input[@type='password'])[2]"));

        private IWebElement SaveButton =>
            driver.FindElement(By.XPath("//button[normalize-space()='Save']"));

        public void AddUser(string empName, string uname, string pwd)
        {
            AdminMenu.Click();
            AddButton.Click();
            EmployeeName.SendKeys(empName);
            Username.SendKeys(uname);
            Password.SendKeys(pwd);
            ConfirmPassword.SendKeys(pwd);
            SaveButton.Click();
        }
    }
}