using FrontEndProject.Tests.Front_End;
using Helpers;
using System;
using System.Reflection;
using Xunit;

namespace FrontEndProject
{
    public class TestChromeDriver : Common
    {
        private readonly string Url;

        public TestChromeDriver()
        {
            Url = Configuration["googleUrl"];
        }

        [Fact]
        public void GoToUrlAndCloseBrowser()
        {
            var driver = WebHelper.BrowserStart();
            WebHelper.BrowserConfigure(driver);

            try
            {
                driver.Navigate().GoToUrl(Url);
            }
            catch (Exception e)
            {
                Log.Information(e.ToString());
                var methodName = MethodBase.GetCurrentMethod().Name;
                Screenshot.TakeScreenshotChrome(driver, methodName);

                throw;
            }
            finally
            {
                WebHelper.BrowserClose(driver);
            }
        }
    }
}
