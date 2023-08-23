using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Calculator.Server.Tests;

public class ServerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ServerTests(WebApplicationFactory<Program> factory) => _factory = factory;

    [Theory]
    [InlineData("/add/3/5", "8")]
    [InlineData("/multiply/3/5", "15")]
    [InlineData("/substract/3/5", "-2")]
    [InlineData("/devide/35/5", "7")]
    public async Task TestAdd(string input, string output)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(input);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(output, await response.Content.ReadAsStringAsync());
    }
}