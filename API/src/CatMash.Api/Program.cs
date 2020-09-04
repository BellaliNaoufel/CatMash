using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CatMash.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BootstrapSerilog();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void BootstrapSerilog()
        {
            //TODO: move this to settings file
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.RollingFile(@"logs\log-{Date}.log")
            .MinimumLevel.Information()
            .CreateLogger();
        }
    }
}