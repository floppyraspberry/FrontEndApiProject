using OpenQA.Selenium;

namespace Helpers
{
    public static class Constants
    {
        public static readonly By NugetChromeDriverVersion = By.XPath("//tbody/tr[2]/td[2]/span[3]");
        public static readonly By GoogleChromeDriverFile = By.XPath("//a[contains(text(),'chromedriver_win32.zip')]");
    }
}
