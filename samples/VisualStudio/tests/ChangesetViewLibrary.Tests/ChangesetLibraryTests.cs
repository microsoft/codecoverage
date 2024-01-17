namespace ChangesetViewLibrary.Tests;

[TestClass]
public class ChangesetLibraryTests
{
    [TestMethod]
    public void TestMethod1()
    {
        _ = ChangesetLibrary.ExistingMethodCovered();
        _ = ChangesetLibrary.ExistingMethod(1);
        _ = ChangesetLibrary.ExistingMethod(2);
    }
}
