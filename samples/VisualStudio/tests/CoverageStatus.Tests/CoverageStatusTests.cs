namespace CoverageStatus.Tests;

[TestClass]
public class CoverageStatusTests
{
    [TestMethod]
    public void CoverageTest()
    {
        _ = CoverageStatus.Covered();
        _ = CoverageStatus.PartiallyCovered(true);
    }
}
