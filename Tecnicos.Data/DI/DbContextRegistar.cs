using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tecnicos.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Tecnicos.Data.DI;

public static class DbContextRegistar
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
    {
        services.AddDbContextFactory<TecnicosContext>(o => o.UseSqlServer("Name=SqlConStr"));
        return services;
    }
}
