using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRMSAutomation.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRMSAutomation.Tests
{
    public class AdminTests
    {
        private IWebDriver driver;

        [SetUp]
       public void Setup()
{
    var chromeOptions = new ChromeOptions();
            new DriverManager().SetUpDriver(new ChromeConfig(), "135.0.7049.116");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }


        [Test]
        public void Add_New_User()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("Admin", "admin123");

            var adminPage = new AdminPage(driver);
            adminPage.AddUser("Linda Anderson", "newuser123", "Password@123");

            Assert.Pass("User creation test completed.");
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