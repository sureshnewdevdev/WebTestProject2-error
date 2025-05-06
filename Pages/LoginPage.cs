using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRMSAutomation.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private IWebElement LoginContainer =>
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".orangehrm-login-slot")));

        private IWebElement UsernameField =>
            driver.FindElement(By.XPath("//input[@placeholder='Username']"));

        private IWebElement PasswordField =>
            driver.FindElement(By.XPath("//input[@placeholder='Password']"));

        private IWebElement LoginButton =>
            driver.FindElement(By.CssSelector("button[type='submit']"));

        public void Login(string username, string password)
        {
            var container = LoginContainer;
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }
    }
}