using Helpers.Configuration;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Helpers
{
    public class BaseTests : IDisposable
    {
        protected static IConfiguration Configuration => ConfigurationRead.Create();
        protected WebHelper WebHelper { get; set; }
        protected HttpClient HttpClientInstance { get; set; }
        protected Serilog.ILogger Log { get; set; }
        protected HttpClient HttpClient { get; set; }

        public BaseTests()
        {
            WebHelper = new WebHelper();
            HttpClientInstance = new HttpClient();
        }

        protected int Get_WaitingTime() => Convert.ToInt32(Configuration["WaitTime"]);

        protected IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(IEnumerable<HttpStatusCode> allowedStatusCodes) => HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(r => !allowedStatusCodes.Contains(r.StatusCode))
            .WaitAndRetryAsync(4, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));

        public void Dispose() {}
    }
}
