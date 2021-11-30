using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;

namespace App
{
    public class Program
    {
        public static void Main()
        {
            IHost host = CreateHostBuilder().Build();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder()
        {
            return new HostBuilder()
               .ConfigureFunctionsWorkerDefaults();
        }
    }
}