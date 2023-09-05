using System.Diagnostics;
using System.IO;
using Xunit;

namespace Calculator.Console.Tests;

public class ConsoleTests
{
#if DEBUG
    private const string Configuration = "Debug";
#else
    private const string Configuration = "Release";
#endif

    [Fact]
    public void AddTest()
    {
        Assert.Equal(7, Execute("add 3 4"));
    }

    [Fact]
    public void MultiplyTest()
    {
        Assert.Equal(12, Execute("multiply 3 4"));
    }

    [Fact]
    public void SubtractTest()
    {
        Assert.Equal(1, Execute("subtract 5 4"));
    }

    [Fact]
    public void DivideTest()
    {
        Assert.Equal(4, Execute("divide 12 3"));
    }

    private double Execute(string arguments)
    {
        string fileName = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Calculator.Console.exe" : "Calculator.Console";

        Process process = new Process();
        process.StartInfo = new ProcessStartInfo()
        {
            FileName = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "..", "src", "Calculator.Console", "bin", Configuration, "net7.0", fileName),
            Arguments = arguments,
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            RedirectStandardError = true,
            RedirectStandardOutput = true
        };
        process.Start();
        double result = double.Parse(process.StandardOutput.ReadToEnd());
        process.WaitForExit();
        return result;
    }
}