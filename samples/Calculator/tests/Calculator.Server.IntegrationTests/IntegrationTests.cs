namespace Calculator.Server.IntegrationTests;

public class IntegrationTests
{
    private readonly HttpClient _client;

    public IntegrationTests()
    {
        _client = new HttpClient()
        {
            BaseAddress = new Uri(" http://localhost:5291"),
        };
    }

    [Theory]
    [InlineData("/add/3/5", "8")]
    [InlineData("/multiply/3/5", "15")]
    [InlineData("/substract/3/5", "-2")]
    [InlineData("/devide/35/5", "7")]
    public async Task TestAdd(string input, string output)
    {
        // Act
        var response = await _client.GetAsync(input);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(output, await response.Content.ReadAsStringAsync());
    }
}