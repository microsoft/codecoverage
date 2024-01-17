namespace ChangesetViewLibrary.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        _ = CoverageLibrary.ExistingMethodCovered();
        _ = CoverageLibrary.ExistingMethod(1);
        _ = CoverageLibrary.ExistingMethod(2);
    }
}
