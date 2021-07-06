using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Helpers
{
    public class WebHelper
    {
        public WebHelper()
        {

        }

        public void BrowserClose(IWebDriver driver)
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
            driver.Dispose();
        }

        public void BrowserConfigure(IWebDriver driver)
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
        }

        public static ChromeDriver BrowserStart(string path = null)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArguments("--incognito");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-gpu");
            options.AddArguments("--disable-infobars");
            options.AddArguments("window-size=2560,1440");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddUserProfilePreference("download.default_directory", path);

            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        }
    }
}
