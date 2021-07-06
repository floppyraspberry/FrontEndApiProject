using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Helpers
{
    public class Screenshot
    {
        public static void TakeScreenshotChrome(ChromeDriver driver, string methodName)
        {
            try
            {
                var filename = Path.Combine(Path.GetTempPath(), $"{methodName}{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.PNG");
                OpenQA.Selenium.Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                screenShot.SaveAsFile(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static void TakeScreenshotWebdriver(IWebDriver driver, string methodName)
        {
            try
            {
                var filename = Path.Combine(Path.GetTempPath(), $"{methodName}{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.PNG");
                OpenQA.Selenium.Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                screenShot.SaveAsFile(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
