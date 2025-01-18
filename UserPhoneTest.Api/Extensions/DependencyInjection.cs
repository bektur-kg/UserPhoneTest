using UserPhoneTest.Application.Extensions;
using UserPhoneTest.Infrastructure.Extensions;

namespace UserPhoneTest.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.RegisterWebApi()
            .RegisterApplication()
            .RegisterInfrastructure(configuration);
    }

    private static IServiceCollection RegisterWebApi(this IServiceCollection services)
    {
        return services;
    }
}
