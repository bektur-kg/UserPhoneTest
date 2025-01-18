using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Application.Services;
using UserPhoneTest.Infrastructure.DbContexts;
using UserPhoneTest.Infrastructure.Modules.Phones;
using UserPhoneTest.Infrastructure.Modules.Users;
using UserPhoneTest.Infrastructure.Services;

namespace UserPhoneTest.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(AppDbContext));

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        })
        .RegisterRepositories()
        .RegisterServices();

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IPhoneRepository, PhoneRepository>();
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
