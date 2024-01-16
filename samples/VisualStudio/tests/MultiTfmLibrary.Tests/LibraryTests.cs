namespace MultiTfmLibrary.Tests;

[TestClass]
public class LibraryTests
{
#if NETFRAMEWORK
    [TestMethod]
    public void FrameworkTest()
    {
        _ = Library.CoveredInAll();
        _ = Library.CoveredInAllConditional();
        _ = Library.CoveredInFramework();
    }
#else
    [TestMethod]
    public void CoreTest()
    {
        _ = Library.CoveredInAll();
        _ = Library.CoveredInAllConditional();
        _ = Library.CoveredInCore();
    }
#endif
}
