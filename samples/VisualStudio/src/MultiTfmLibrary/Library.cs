namespace MultiTfmLibrary;

public static class Library
{
    public static string CoveredInAll()
    {
        return "Covered in all TFMs";
    }

    public static string CoveredInAllConditional()
    {
#if NETFRAMEWORK
        return "Covered in framework";
#else
        return "Covered in core";
#endif
    }

#if NETFRAMEWORK
    public static string CoveredInFramework()
    {
        return "Covered in framework only";
    }
#else
    public static string CoveredInCore()
    {
        return "Covered in core only";
    }
#endif
}
