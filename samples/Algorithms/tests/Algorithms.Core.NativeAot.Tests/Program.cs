using Microsoft.Testing.Extensions;
using Microsoft.Testing.Framework;
using Microsoft.Testing.Platform.Builder;

namespace Algorithms.Core.NativeAot.Tests;

internal static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var builder = await TestApplication.CreateBuilderAsync(args);
        builder.AddTestFramework(new SourceGeneratedTestNodesBuilder());
        builder.AddTrxReportProvider();
        builder.AddCodeCoverageProvider();
        var app = await builder.BuildAsync();
        return await app.RunAsync();
    }
}
