namespace ChangesetViewLibrary;

public static class ChangesetLibrary
{
    public static string ExistingMethodCovered()
    {
        return "Covered in main branch";
    }

    public static string ExistingMethodNotCovered()
    {
        return "Not Covered in main branch";
    }

    public static string ExistingMethod(int condition)
    {
        if (condition == 1)
        {
            Console.WriteLine(condition);
            return "condition = 1";
        }
        else if (condition == 2)
        {
            Console.WriteLine(condition);
            return "condition = 1";
        }
        else
        {
            Console.WriteLine(condition);
            return $"condition = {condition}";
        }
    }
}
