namespace SourceViewLibrary;

public static class MathHelpers
{
    public static int Add(int a, int b) => a + b;

    public static int Subtract(int a, int b) => a - b;
}

public static class DirectoryHelpers
{
    public static bool DirectoryExists(string path) => Directory.Exists(path);
}

public static class FileHelpers
{
    public static bool FileExists(string path) => File.Exists(path);
}
