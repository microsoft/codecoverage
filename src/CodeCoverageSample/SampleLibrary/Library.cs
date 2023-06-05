namespace SampleLibrary;

public static class Library
{
    public static void FullyCovered()
    {
        Console.WriteLine("Fully Covered");
    }

    public static void FullyCovered(bool condition)
    {
        if (condition)
            Console.WriteLine("Fully Covered");
        else
            Console.WriteLine("Not Covered");
    }

    public static void PartiallyCovered(bool condition)
    {
        string results = condition == true ? "True" : "False";
        Console.WriteLine(results);
    }

    public static void NotCovered()
    {
        Console.WriteLine("Not Covered");
    }
}
