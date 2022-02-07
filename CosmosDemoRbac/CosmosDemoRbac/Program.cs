using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace CosmosDemoRbac
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseNServiceBus(ctx =>
            {
                var endpointConfiguration = new EndpointConfiguration("MyEndpoint");
                
                var persistence = endpointConfiguration.UsePersistence<CosmosPersistence>();
                persistence.DatabaseName(ctx.Configuration["Cosmos:Db"]);
                var credential = new DefaultAzureCredential();
                var cosmosClient = new CosmosClient(ctx.Configuration["Cosmos:Uri"], credential);
                persistence.CosmosClient(cosmosClient);
                persistence.DefaultContainer(ctx.Configuration["Cosmos:Container"], "/id");

                var transport = endpointConfiguration.UseTransport<LearningTransport>();
                transport.StorageDirectory(".learningtransport");
                endpointConfiguration.EnableInstallers();
                return endpointConfiguration;
            })
            .ConfigureServices((hostContext, services) => { services.AddHostedService<Worker>(); });
    }
}