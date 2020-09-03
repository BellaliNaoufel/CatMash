using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Front.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            // configure api versionning
            services.AddVersionedApiExplorer(
              options =>
              {
                  //The format of the version added to the route URL
                  options.GroupNameFormat = "'v'VV"; // Only the major and minor version of the API version
                  //Tells swagger to replace the version in the controller route
                  options.SubstituteApiVersionInUrl = true;
              }); ;

            // configure swagger documentation
            services.AddApiVersioning(options => options.ReportApiVersions = true);
        }
    }
}
