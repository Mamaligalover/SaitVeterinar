using VeterinarSite.Client.Services;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Server.ServiceDependencyInjections;

public static class DependencyInjections
{
    public static IServiceCollection AddServerDependencyInjections(this IServiceCollection services)
    {
        services.AddTransient<IMedicalWorker, MedicalWorkerServices>();
        return services;
    }
}