using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OrangeHRMSAutomation.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRMSAutomation.Tests
{
    public class LoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1920,1080");

            // Path to folder containing chromedriver.exe
            driver = new ChromeDriver(@"C:\SeleniumDrivers\chromedriver-win64\chromedriver-win64\", chromeOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }

        [Test]
        public void Login_With_Valid_Credentials()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("Admin", "admin123");
            //Assert.That(driver.Url.Contains("dashboard") || driver.PageSource.Contains("Dashboard"), Is.True);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url.Contains("dashboard") || d.PageSource.Contains("Dashboard"));

            Assert.That(driver.Url.Contains("dashboard") || driver.PageSource.Contains("Dashboard"), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}