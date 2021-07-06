//using Helpers;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Compression;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using Xunit;
//using Xunit.Abstractions;

//namespace FrontEndProject.Tests
//{
//    public class DownloadChromeDriver : BaseTests
//    {
//        private ITestOutputHelper TestOutputHelper { get; }
//        private readonly string LocalProjectFolder;
//        private readonly string DownloadFolder;


//        public DownloadChromeDriver(ITestOutputHelper testOutputHelper)
//        {
//            TestOutputHelper = testOutputHelper;
//            LocalProjectFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
//            DownloadFolder = SelectPath();
//        }

//        public void DownloadChromeDriverFile()
//        {
//            var nugetChromeVersion = CheckChromeVersionInNuget();

//            string localChromeVersion = CheckLocalChromeVersion();

//            if (localChromeVersion != nugetChromeVersion)
//            {
//                GetLatestStableChromeVersion(nugetChromeVersion);
//                ExtractCompressedChromeDriverFile();
//            }
//        }

//        private string CheckLocalChromeVersion()
//        {
//            var driver = WebHelper.BrowserStart();
//            var localChromeVersion = String.Empty;
//            try
//            {
//                ICapabilities capabilities = driver.Capabilities;
//                var chromeVersion = (capabilities.GetCapability("chrome") as Dictionary<string, object>)["chromedriverVersion"];
//                localChromeVersion = chromeVersion.ToString().Split(" ")[0];
//                TestOutputHelper.WriteLine($"The local chromeDriver version is: {localChromeVersion}");
//            }
//            catch (Exception e)
//            {
//                TestOutputHelper.WriteLine(e.ToString());
//            }
//            finally
//            {
//                WebHelper.BrowserClose(driver);
//            }
//            return localChromeVersion;
//        }

//        private string CheckChromeVersionInNuget()
//        {
//            var driver = WebHelper.BrowserStart();
//            var waitInSec = Get_WaitingTime();
//            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, waitInSec));
//            var url = Configuration["nuget_version_url"];
//            var nugetChromeVersion = String.Empty;
//            try
//            {
//                WebHelper.BrowserConfigure(driver);
//                driver.Navigate().GoToUrl(url);
//                var getVersion = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Constants.NugetChromeDriverVersion)).Text;
//                nugetChromeVersion = getVersion.Trim(new Char[] { ' ', '\\', '\"' });
//                TestOutputHelper.WriteLine($"The ChromeDriver version in the Nuget is: {nugetChromeVersion}");
//                Assert.NotNull(nugetChromeVersion);
//                Assert.NotEmpty(nugetChromeVersion);
//            }
//            catch (Exception e)
//            {
//                TestOutputHelper.WriteLine(e.ToString());
//                var methodName = MethodBase.GetCurrentMethod().Name;
//                Helpers.Screenshot.TakeScreenshotChrome(driver, methodName);
//            }
//            finally
//            {
//                WebHelper.BrowserClose(driver);
//            }
//            return nugetChromeVersion;
//        }
//        private void GetLatestStableChromeVersion(string versionNumber)
//        {
//            var driver = WebHelper.BrowserStart(DownloadFolder);

//            var waitInSec = Get_WaitingTime();
//            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, waitInSec));
//            try
//            {
//                WebHelper.BrowserConfigure(driver);
//                var baseUri = Configuration["chromedriver_download_url"];
//                var downloadUrl = new Uri($"{baseUri}{versionNumber}/");
//                TestOutputHelper.WriteLine($"The ChromeDriver downloadUrl is: {downloadUrl.ToString()}");

//                driver.Navigate().GoToUrl(downloadUrl);

//                var downloadZipFile = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Constants.GoogleChromeDriverFile));
//                driver.FindElement(Constants.GoogleChromeDriverFile).Click();

//                string path = Path.Combine(DownloadFolder, $"chromedriver_win32.zip");
//                while (File.Exists(path) == false)
//                {
//                    System.Threading.Thread.Sleep(1000);
//                }
//            }
//            catch (Exception e)
//            {
//                TestOutputHelper.WriteLine(e.ToString());
//                var methodName = MethodBase.GetCurrentMethod().Name;
//                Helpers.Screenshot.TakeScreenshotChrome(driver, methodName);
//            }
//            finally
//            {
//                WebHelper.BrowserClose(driver);
//            }
//        }

//        private void ExtractCompressedChromeDriverFile()
//        {
//            string path = Path.Combine(LocalProjectFolder, $"chromedriver_win32.zip");
//            TestOutputHelper.WriteLine($"local path: {LocalProjectFolder}. Full path: {path}. DownloadFolder: {DownloadFolder} ");
//            string downloadedFile = Path.Combine(DownloadFolder, $"chromedriver_win32.zip");
//            if (File.Exists(path))
//            {
//                File.Delete(path);
//            }
//            ZipFile.ExtractToDirectory(downloadedFile, path);
//        }

//        private string SelectPath()
//        {
//            var downloadLocation = String.Empty;
//            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
//            TestOutputHelper.WriteLine($"Bool IsWindows: {isWindows}");

//            if (isWindows == true)
//            { downloadLocation = Path.Combine(LocalProjectFolder, "Temp\\"); }
//            else
//            { downloadLocation = $"/tmp/ChromeDriver/"; }

//            TestOutputHelper.WriteLine($"DownloadLocation: {downloadLocation}");

//            return downloadLocation;
//        }
//    }
//}
