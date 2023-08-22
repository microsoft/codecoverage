namespace Calculator.Core;

public static class OperationCalculator
{
    public const string Add = "add";
    public const string Multiply = "multiply";
    public const string Substract = "substract";
    public const string Devide = "devide";

    public static double Calculate(string operation, double a, double b)
    {
        switch (operation)
        {
            case Add:
                return CalculateAdd(a, b);
            case Multiply:
                return CalculateMultiply(a, b);
            case Substract:
                return CalculateSubstract(a, b);
            case Devide:
                return CalculateDevide(a, b);
            default:
                throw new InvalidOperationException("Invalid operation name");
        }
    }

    public static double CalculateAdd(double a, double b) => a + b;
    public static double CalculateMultiply(double a, double b) => a * b;
    public static double CalculateSubstract(double a, double b) => a - b;
    public static double CalculateDevide(double a, double b) => a / b;
}
