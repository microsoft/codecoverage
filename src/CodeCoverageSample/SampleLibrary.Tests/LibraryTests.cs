namespace SampleLibrary.Tests;

[TestClass]
public class LibraryTests
{
    [TestMethod]
    public void FullyCovered_Test()
    {
        Library.FullyCovered();
    }

    [TestMethod]
    public void FullyCovered_TrueCondition()
    {
        Library.FullyCovered(true);
    }

    [TestMethod]
    public void FullyCovered_FalseCondition()
    {
        Library.FullyCovered(false);
    }

    [TestMethod]
    public void PartiallyCovered_Test()
    {
        Library.PartiallyCovered(false);
    }
}
