using Microsoft.OpenApi.Models;
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
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "UserPhone.API", Version = "v1" });
        });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
        });

        return services;
    }
}
