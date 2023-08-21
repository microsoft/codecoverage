using library;
using Xunit;

namespace library.tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(12, Class1.Add(3, 9));
    }
}