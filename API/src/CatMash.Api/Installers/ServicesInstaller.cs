using CatMash.Domain.Business;
using CatMash.Domain.Interface.Business;
using CatMash.Front.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatMash.Front.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICatsBusiness, CatsBusiness>();

            services.AddOptions<CatsApiSettings>()
               .Configure<IConfiguration>((settings, config) =>
               {
                   config.GetSection("CatsApiSettings").Bind(settings);
               });
        }
    }
}