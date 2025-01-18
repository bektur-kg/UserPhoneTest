using UserPhoneTest.Api.Middlewares;

namespace UserPhoneTest.Api.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
