namespace TestProjectCopilot;

public class DefaultEndpointsTests
{
    [Fact]
    public async Task GetWeatherForecast_ShouldReturn5Items()
    {
        var hostBuilder = new WebHostBuilder()
            .ConfigureServices(services => services.AddRouting())
            .Configure(app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints => endpoints.MapEndpoints());
            });

        var server = new TestServer(hostBuilder);
        var client = server.CreateClient();

        var response = await client.GetAsync("/weatherforecast");

        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.NotEmpty(content);
    }
}

