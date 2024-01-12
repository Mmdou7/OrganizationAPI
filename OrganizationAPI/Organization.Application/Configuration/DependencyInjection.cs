using Microsoft.Extensions.DependencyInjection;

namespace Organization.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
