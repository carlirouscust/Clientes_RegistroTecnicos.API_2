using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tecnicos.Data.DI;
using Tecnicos.Abstractions;

namespace Tecnicos.Services.DI;

public static class ServiceRegistrar
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.RegisterDbContextFactory();
        services.AddScoped<IClientesService, ClientesService>();
        return services;
    }
}
