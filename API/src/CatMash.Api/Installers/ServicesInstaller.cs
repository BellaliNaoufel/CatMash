using CatMash.Domain.Business;
using CatMash.Domain.Interface;
using CatMash.Domain.Interface.Business;
using CatMash.Domain.Interface.Repository;
using CatMash.Infrastructure.Data;
using CatMash.Infrastructure.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatMash.Front.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
