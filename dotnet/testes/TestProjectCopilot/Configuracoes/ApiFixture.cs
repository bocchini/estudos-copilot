
namespace TestProjectCopilot.Configuracoes;

public class ApiFixture
{
    private readonly CustomWebApplicationFactory _webApplicationFactory;

    public ApiFixture()
    {
        _factory = new CustomWebApplicationFactory<Program>();
    }

    public HttpClient CreateClient()
    {
        return _factory.CreateClient();
    }
}
