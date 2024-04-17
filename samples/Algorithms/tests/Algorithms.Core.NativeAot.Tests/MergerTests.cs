[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace Algorithms.Core.NativeAot.Tests;

[TestClass]
public class MergerTests
{
    [TestMethod]
    public void Test1()
    {
        var result = Merger.Merge([1, 3, 5], [2, 4, 5, 6]);
        AssertArrays([1, 2, 3, 4, 5, 5, 6], result);
    }

    [TestMethod]
    public void Test2()
    {
        var result = Merger.Merge([], [2, 4, 5, 6]);
        AssertArrays([2, 4, 5, 6], result);
    }

    [TestMethod]
    public void Test3()
    {
        var result = Merger.Merge([2, 4, 5, 6], []);
        AssertArrays([2, 4, 5, 6], result);
    }

    private void AssertArrays(int[] expected, int[] actual)
    {
        Assert.AreEqual(expected.Length, actual.Length, $"Sizes of arrays are different. expected.Length={expected.Length} actual.Length={actual.Length}");
        for (int index = 0; index < expected.Length; index++)
            Assert.AreEqual(expected[index], actual[index], $"Arrays different on index={index}. expected[{index}]={expected[index]} actual[{index}]={actual[index]}");
    }
}
