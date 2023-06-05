namespace WpfApplication.Tests;

[TestClass]
public class MainWindoTests
{
    [TestMethod]
    public void Add_Test()
    {
        Assert.AreEqual(5, MainWindow.Add(3, 2));
    }
}
