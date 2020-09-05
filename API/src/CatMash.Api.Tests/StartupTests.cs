using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NFluent;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace CatMash.Api.Tests
{
    public class StartupTests
    {
        private readonly Startup _subject;
        private readonly IServiceCollection _services;

        public StartupTests(ITestOutputHelper output)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appSettings.json");

            var configuration = builder.Build();
            _subject = new Startup(configuration);

           // _services = InitializeServiceCollection(output);
        }

        [Fact]
        public void Configure_HappyPath_CanResolveEventController()
        {
            //_services.AddTransient<EventController>();
            //_subject.ConfigureServices(_services);
            //var serviceProvider = _services.BuildServiceProvider();

            //var actual = serviceProvider.GetRequiredService<EventController>();
           // Check.That(actual).IsNotNull();
        }

    }
}
