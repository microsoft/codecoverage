namespace Calculator.Core;

public static class OperationCalculator
{
    public const string Add = "add";
    public const string Multiply = "multiply";
    public const string Subtract = "subtract";
    public const string Divide = "divide";

    public static double Calculate(string operation, double a, double b)
    {
        switch (operation)
        {
            case Add:
                return CalculateAdd(a, b);
            case Multiply:
                return CalculateMultiply(a, b);
            case Subtract:
                return CalculateSubtract(a, b);
            case Divide:
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
