

using Copilot.Testes.API.Endpoints;

namespace Copilot.Testes.API.Extensions;

public static class AppConfigureExtensions
{
    public static void Configure(this WebApplication app)
    {
        app.MapEndpoints();
    }
}
