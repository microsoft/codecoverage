namespace CodeCoverage.WinUI3Sample;

public static class CoverageCalculator
{
    public static int Add(int left, int right) => left + right;

    public static string Describe(int value)
    {
        if (value > 0)
        {
            return "positive";
        }

        return value < 0 ? "negative" : "zero";
    }
}
