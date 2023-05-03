namespace TestProject;

[TestClass]
public class UnitTest1
{
    private readonly bool _isFramework;
    private readonly bool _isCore;
    private readonly bool _all;

    public UnitTest1()
    {
#if NETFRAMEWORK
        _isFramework = true;
        _isCore = false;
#else
        _isFramework = false;
        _isCore = true;
#endif
        _all = true;
    }

#if NETFRAMEWORK
    [TestMethod]
    public void FrameworkTest()
    {
        Assert.IsTrue(_isFramework);
        Assert.IsFalse(_isCore);
        Assert.IsTrue(_all);
    }
#else
    [TestMethod]
    public void CoreTest()
    {
        Assert.IsFalse(_isFramework);
        Assert.IsTrue(_isCore);
        Assert.IsTrue(_all);
    }
#endif

    [TestMethod]
    public void AllTest()
    {
#if NETFRAMEWORK
        Assert.IsTrue(_isFramework);
# else
        Assert.IsTrue(_isCore);
#endif
        Assert.IsTrue(_all);
    }
}