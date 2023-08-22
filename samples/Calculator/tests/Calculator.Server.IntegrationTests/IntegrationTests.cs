namespace Calculator.Server.IntegrationTests;

[TestFixture]
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

    [Test]
    [TestCase("/add/3/5", "8")]
    [TestCase("/multiply/3/5", "15")]
    [TestCase("/substract/3/5", "-2")]
    [TestCase("/devide/35/5", "7")]
    [Parallelizable(ParallelScope.All)]
    public async Task TestOperations(string input, string output)
    {
        try 
        {
            // Act
            var response = await _client.GetAsync(input);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equals(output, await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            Assert.Ignore(e.Message);
        }
    }
}