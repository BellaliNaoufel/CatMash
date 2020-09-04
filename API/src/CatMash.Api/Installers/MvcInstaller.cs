using AutoMapper;
using CatMash.Api;
using CatMash.Api.Filters;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatMash.Front.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddVersionedApiExplorer(
              options =>
              {
                  options.GroupNameFormat = "'v'VV";
                  options.SubstituteApiVersionInUrl = true;
              }); ;

            services.AddApiVersioning(options => options.ReportApiVersions = true);
        }
    }
}