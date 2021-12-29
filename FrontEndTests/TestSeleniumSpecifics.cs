using FrontEndProject.Tests.Front_End;
using Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Reflection;
using Xunit.Abstractions;

namespace FrontEndProject
{
    public class TestSeleniumSpecifics : Common
    {
        public IAction Action { get; set; }
        private readonly ITestOutputHelper _testOutputHelper;

        public TestSeleniumSpecifics(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public void HandleElements()
        {
            var driver = new ChromeDriver();
            var actions = new Actions(driver);
            try
            { 
                var url = "http://automationpractice.com/index.php";
                driver.Navigate().GoToUrl(url);
                //actions.MoveToElement();
            }
            catch(Exception ex)
            {
                var methodName = MethodBase.GetCurrentMethod().Name;
                _testOutputHelper.WriteLine(ex.ToString());
                Screenshot.TakeScreenshotChrome(driver,methodName);
                throw;
            }
        }


        // TODO: add tests:
        // - add project to Azure
        // - selenium grid
        // - remote webdriver
        // - different browsers
        // - keyboard manipulation https://www.selenium.dev/documentation/en/webdriver/keyboard/
        // - pageLoad strategy https://www.selenium.dev/documentation/en/webdriver/page_loading_strategy/
        // - javasscript 
        // - waits
        // - browser manipulation   https://www.selenium.dev/documentation/en/webdriver/browser_manipulation/
        // -

    }
}
