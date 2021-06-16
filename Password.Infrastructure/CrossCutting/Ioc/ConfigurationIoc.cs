using Microsoft.Extensions.DependencyInjection;
using Password.Application;
using Password.Application.Interfaces;
using Password.Application.Mappers;
using Password.Domain.Services;
using Password.Domian.Core.Interfaces.Repositories;
using Password.Domian.Core.Interfaces.Services;
using Password.Infrastructure.Data.Repositories;

namespace Password.Infrastructure.CrossCutting.Ioc
{
    public static class ConfigurationIoc
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationServiceSettingsPassword, ApplicationServicePasswordSettings>();
            serviceCollection.AddScoped<IApplicationServicePassword, ApplicationServicePassword>();
            serviceCollection.AddScoped<IServicePasswordSettings, ServicePasswordSettings>();
            serviceCollection.AddScoped<IRepositoryPasswordSettings, RepositoryPasswordSettings>();
            serviceCollection.AddAutoMapper(typeof(MapperPasswordSettings));
        }
    }
}