using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Password.Application;
using Password.Application.Interfaces;
using Password.Domain.Services;
using Password.Domian.Core.Interfaces.Repositories;
using Password.Domian.Core.Interfaces.Services;
using Password.Infrastructure.CrossCutting.Ioc;
using Password.Infrastructure.Data.Context;
using Password.Infrastructure.Data.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Password.Test.Unit.Ios
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ConfigurationIocTests
    {
        [Test]
        public void ConfigurationIoc_ShouldRetunsNewInstance()
        {
            var services = new ServiceCollection();
            services.AddDbContext<SqlContext>(options =>
                options.UseSqlServer("Server=localhost;Database=Iti;User Id=sa;Password=p4ssw0rd!"));
            ConfigurationIoc.RegisterServices(services);
            var serviceProvider = services.BuildServiceProvider();

            Assert.IsInstanceOf<ApplicationServicePasswordSettings>(serviceProvider
                .GetService<IApplicationServiceSettingsPassword>());
            Assert.IsInstanceOf<ApplicationServicePassword>(serviceProvider.GetService<IApplicationServicePassword>());
            Assert.IsInstanceOf<ServicePasswordSettings>(serviceProvider.GetService<IServicePasswordSettings>());
            Assert.IsInstanceOf<RepositoryPasswordSettings>(serviceProvider.GetService<IRepositoryPasswordSettings>());

            serviceProvider.Dispose();
        }
    }
}