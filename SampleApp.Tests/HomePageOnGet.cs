using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

using SampleApp;

using Xunit;

namespace SampleApp.Tests
{
    public class HomePageOnGet : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public HomePageOnGet(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsHomePageWithProductListing()
        {
            // Arrange & Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("Success", stringResponse);
            Assert.Contains("OpenShift", stringResponse);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
