using Calculator.Core;
using Xunit;

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
    public void TestSubtract()
    {
        Assert.Equal(-7, OperationCalculator.CalculateSubtract(2, 9));
    }


    [Fact]
    public void TestDivide()
    {
        Assert.Equal(9.0, OperationCalculator.CalculateDivide(18.0, 2.0));
    }
}