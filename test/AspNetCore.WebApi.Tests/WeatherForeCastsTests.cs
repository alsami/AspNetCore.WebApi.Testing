using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace AspNetCore.WebApi.Tests
{
    public class WeatherForeCastsTests
    {
        [Fact]
        public async Task LoadWeatherForecastAsync()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(AppContext.BaseDirectory)
                .ConfigureAppConfiguration(builder =>
                {
                    builder.Sources.Clear();
                    builder.SetBasePath(AppContext.BaseDirectory);
                    builder.AddJsonFile("appsettings.Testing.json", false);
                })
                .UseStartup<Startup>();

            var host = new TestServer(webHostBuilder);

            var response = await host.CreateClient().GetAsync("weatherforecast");
            
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}