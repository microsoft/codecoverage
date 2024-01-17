namespace CoverageStatus;

public static class CoverageStatus
{
    public static string Covered()
    {
        return "Covered";
    }

    public static string NotCovered()
    {
        return "Not covered";
    }

    public static string PartiallyCovered(bool enabled)
    {
        return enabled ? "Partially covered" : "Not covered";
    }
}
