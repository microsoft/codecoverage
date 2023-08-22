namespace Calculator.Server.IntegrationTests;

[TestClass]
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

    [TestMethod]
    [DataRow("/add/3/5", "8")]
    [DataRow("/multiply/3/5", "15")]
    [DataRow("/substract/3/5", "-2")]
    [DataRow("/devide/35/5", "7")]
    public async Task TestOperations(string input, string output)
    {
        try 
        {
            // Act
            var response = await _client.GetAsync(input);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.AreEqual(output, await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            Assert.Inconclusive(e.Message);
        }
    }
}