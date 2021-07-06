using Helpers;
using System;
using Xunit;

namespace FrontEndProject
{
    public class TestChromeDriver : BaseTests
    {
        public TestChromeDriver()
        {
                
        }

        [Fact]
        public void GoToBrowser()
        {
            var driver = WebHelper.BrowserStart();
            var url = "https://www.google.com";
            WebHelper.BrowserConfigure(driver);

            try
            {
                driver.Navigate().GoToUrl(url);

            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
            }
            finally
            {
                WebHelper.BrowserClose(driver);
            }
        }
    }
}
