using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OrangeHRMSAutomation.Utils
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            return driver;
        }
    }
}