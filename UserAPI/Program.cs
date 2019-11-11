using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace UserAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) =>
            {
                var hostingEnv = webHostBuilderContext.HostingEnvironment;
                configurationBuilder.AddConfigServer(hostingEnv.EnvironmentName);
            })
                .UseStartup<Startup>();
    }
}
