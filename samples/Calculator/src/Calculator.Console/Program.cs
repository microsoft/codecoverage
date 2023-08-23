using Calculator.Core;

internal class Program
{
    private static int Main(string[] args)
    {
        if (args.Length != 3)
        {
            PrintHelp();
            return -1;
        }

        string operation = args[0].ToLower();
        double a = Convert.ToDouble(args[1]);
        double b = Convert.ToDouble(args[2]);

        Console.WriteLine(OperationCalculator.Calculate(operation, a, b));
        return 0;
    }

    private static void PrintHelp()
    {
        Console.WriteLine(Help);
    }

    private const string Help = @"Invalid usage

Example usage:
    dotnet run ""add"" 3 5
    dotnet run ""multiply"" 4 6
    dotnet run ""substract"" 12 5
    dotnet run ""devide"" 12 3
    ";
}