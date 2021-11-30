using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace App.FunctionalTests
{
    public class UnitTest1
    {
        private string _baseAddress;
        private IHttpClientFactory _clientFactory;

        public UnitTest1()
        {
            
            var host = Program.CreateHostBuilder()
               .ConfigureFunctionsWorkerDefaults(d =>
                {
                    
                })
               
               .Build();

            host.Start();

            _baseAddress = host.Services.GetService<IServer>().Features.Get<IServerAddressesFeature>().Addresses.First();
            _clientFactory = host.Services.GetRequiredService<IHttpClientFactory>();
        }

        [Fact]
        public async Task Test()
        {
            var result = await _clientFactory.CreateClient().GetAsync($"{_baseAddress}/httpfunc");
            Assert.True(result.StatusCode == HttpStatusCode.OK);
        }
    }
}