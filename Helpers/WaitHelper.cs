using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace Helpers
{
    public class WaitHelper
    {

        public static IWebElement WaitUntilElementVisible(ChromeDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));
                Serilog.Log.Debug("Element with locator: '" + elementLocator + "' was found.");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Debug.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
    }
}
