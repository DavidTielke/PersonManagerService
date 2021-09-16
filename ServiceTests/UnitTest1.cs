using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient;
using ServiceClient.Models;

namespace ServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        private TestServer _server;
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task TestMethodAsync()
        {
            var response = await _client.GetAsync("/people");

            response.EnsureSuccessStatusCode();

            var data = await response
                .Content
                .ReadFromJsonAsync<IEnumerable<Person>>();

            data.Count().Should().Be(4);
        }
    }
}
