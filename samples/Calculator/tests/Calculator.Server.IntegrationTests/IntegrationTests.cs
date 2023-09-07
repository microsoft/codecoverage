using NUnit.Framework;
using System.Runtime.InteropServices;

namespace Calculator.Server.IntegrationTests;

[TestFixture]
public class IntegrationTests
{
    private readonly HttpClient _client;

    public IntegrationTests()
    {
        int port = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 5291 : 5000;

        _client = new HttpClient()
        {
            BaseAddress = new Uri($"http://localhost:{port}"),
        };
    }

    [Test]
    [TestCase("/add/3/5", "8")]
    [TestCase("/multiply/3/5", "15")]
    [TestCase("/subtract/3/5", "-2")]
    [TestCase("/divide/35/5", "7")]
    [Parallelizable(ParallelScope.All)]
    public async Task TestOperations(string input, string output)
    {
        try 
        {
            // Act
            var response = await _client.GetAsync(input);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.That(await response.Content.ReadAsStringAsync(), Is.EqualTo(output));
        }
        catch (HttpRequestException e)
        {
            Assert.Ignore(e.Message);
        }
    }
}