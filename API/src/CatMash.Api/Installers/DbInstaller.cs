using CatMash.Domain.Interface;
using CatMash.Infrastructure.Data;
using CatMash.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatMash.Front.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatMashDbContext>(options => options.UseSqlite(configuration.GetConnectionString("SqLite")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}