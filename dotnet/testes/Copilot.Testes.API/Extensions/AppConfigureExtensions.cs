

using Copilot.Testes.API.Endpoints;

namespace Copilot.Testes.API.Extensions;

public static class AppConfigureExtensions
{
    public static void Configure(this WebApplication app)
    {
        app.MapEndpoints();
        SwaggerMap(app);
    }

    private static void SwaggerMap(WebApplication app)
    {
        app.UseSwaggerUI();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/v1/swagger.json", "Copilot.Testes.API v1");
            options.DisplayRequestDuration();
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            options.ShowCommonExtensions();
        });
    }

}
