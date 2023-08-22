using Calculator.Core;

namespace Calculator.Core.Tests;

public class CalculatorUnitTests
{
    [Fact]
    public void TestAdd()
    {
        Assert.Equal(11, OperationCalculator.CalculateAdd(2, 9));
    }

    [Fact]
    public void TestMultiply()
    {
        Assert.Equal(18, OperationCalculator.CalculateMultiply(2, 9));
    }

    [Fact]
    public void TestSubstract()
    {
        Assert.Equal(-7, OperationCalculator.CalculateSubstract(2, 9));
    }


    [Fact]
    public void TestDevide()
    {
        Assert.Equal(9.0, OperationCalculator.CalculateDevide(18.0, 2.0));
    }
}