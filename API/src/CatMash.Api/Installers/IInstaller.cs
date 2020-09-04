using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatMash.Front.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}