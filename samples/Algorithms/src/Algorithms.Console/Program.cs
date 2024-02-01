// See https://aka.ms/new-console-template for more information
using Algorithms.Core;

int[] a = [1, 5, 10, 15];
int[] b = [0, 3, 4, 6, 7, 20];

Print(nameof(a), a);
Print(nameof(b), b);
Print("merged:", Merger.Merge(a, b));

void Print(string name, int[] array)
{
    Console.WriteLine($"{name}: [{string.Join(",", array)}]");
}
