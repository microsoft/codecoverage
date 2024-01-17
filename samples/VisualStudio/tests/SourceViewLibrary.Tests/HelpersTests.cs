namespace SourceViewLibrary.Tests;
extern alias library;

[TestClass]
public class HelpersTests
{
    [TestMethod]
    public void CoverageTests()
    {
        _ = library.SourceViewLibrary.MathHelpers.Add(1, 2);
        _ = library.SourceViewLibrary.DirectoryHelpers.DirectoryExists("somePath");
        _ = MathHelpers.Subtract(1, 2);
        _ = DirectoryHelpers.DirectoryExists("somePath");
    }
}
