namespace Calculator.Core;

public static class OperationCalculator
{
    public static double Calculate(string operation, double a, double b)
    {
        switch (operation)
        {
            case OperationConsts.Add:
                return CalculateAdd(a, b);
            case OperationConsts.Multiply:
                return CalculateMultiply(a, b);
            case OperationConsts.Subtract:
                return CalculateSubtract(a, b);
            case OperationConsts.Divide:
                return CalculateDivide(a, b);
            default:
                throw new InvalidOperationException("Invalid operation name");
        }
    }

    public static double CalculateAdd(double a, double b) => a + b;
    public static double CalculateMultiply(double a, double b) => a * b;
    public static double CalculateSubtract(double a, double b) => a - b;
    public static double CalculateDivide(double a, double b) => a / b;
}
