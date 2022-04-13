using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MovieDatabase.API.Tests.Tests;

public class MovieControllerTests : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private readonly InMemoryWebApplicationFactory<Program> _factory;

    public MovieControllerTests(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAllMovies_HttpStatusCode_Returns_OK()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api/movies");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}