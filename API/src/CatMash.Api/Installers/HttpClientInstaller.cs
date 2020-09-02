using CatMash.Front.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Front.Installers
{
    public class HttpClientInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("CatsApiClient", (sp, client) =>
              {
                  var config = sp.GetService<IConfiguration>();
                  client.BaseAddress = new Uri(config["CatsApiSettings:BaseUrl"]);
              });

            services.AddOptions<CatsApiSettings>()
              .Configure<IConfiguration>((settings, config) =>
              {
                  config.GetSection("CatsApiSettings").Bind(settings);
              });
        }
    }
}
