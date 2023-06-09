﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VeterinarSite.Persistance;

public static class ServiceSetup
{
    public static IServiceCollection AddVeterinarSitesContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name));
            options.EnableSensitiveDataLogging(true);
        });
        return services;
    }
}