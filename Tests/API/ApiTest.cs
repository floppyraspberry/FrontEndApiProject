using System;
using System.Net;
using Helpers;
using Helpers.Models;
using Newtonsoft.Json;
using Xunit;

namespace FrontEndProject.Tests.API
{
    public class ApiTest : BaseTests
    {
        private readonly string BaseUrl;

        public ApiTest()
        {
            BaseUrl = "https://api.coingecko.com/api/v3/";

        }

        [Fact]
        public async void CoinGeckoApiHealthCheck()
        {
            try
            {
                var url1 = Configuration["GeckoUrl"];
                var url2 = Urls.GeckoBaseUrl;
                var url = $"{BaseUrl}ping";
                var response = HttpClientInstance.GetAsync(url);
                var actual = await response.Result.Content.ReadAsStringAsync();

                var content = JsonConvert.DeserializeObject<GeckoApiHealthResponse>(actual);
                Assert.Contains("(V3) To the Moon!", actual);
                Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
            }
            finally
            {
                Dispose();
            }
        }

        [Theory]
        [InlineData("stellar", "dogecoin")]
        [InlineData("dodo", "dogecoin")]
        [InlineData("talleo", "stellar")]
        [InlineData("dodo", "talleo")]
        public async void CoinGeckoGetPriceTests(string crypto, string anotherCrypto)
        {
            try
            {
                var url = $"{BaseUrl}simple/price?ids={crypto}&vs_currencies={anotherCrypto}";
                var response = HttpClientInstance.GetAsync(url);
                var actual = await response.Result.Content.ReadAsStringAsync();

                var content = JsonConvert.DeserializeObject<GeckoApiHealthResponse>(actual);
                Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
            }
            finally
            {
                Dispose();
            }
        }

        [Fact]
        public async void CoinGeckoGetCoinHistory()
        {
            try
            {
                var date = DateTime.Now.AddYears(-1).ToString("dd-MM-yyyy");
                var url = $"{BaseUrl}coins/stellar/history?date={date}&localization=false";
                var response = HttpClientInstance.GetAsync(url);
                var actual = await response.Result.Content.ReadAsStringAsync();

                var content = JsonConvert.DeserializeObject<GeckoCoinHistoryResponse>(actual);
                
                Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
            }
            finally
            {
                Dispose();
            }
        }
    }
}
