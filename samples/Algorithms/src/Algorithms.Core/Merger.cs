namespace Algorithms.Core;

public static class Merger
{
    public static int[] Merge(int[] array1, int[] array2)
    {
        int index1 = 0;
        int index2 = 0;
        int index = 0;

        var target = new int[array1.Length + array2.Length];

        while (index1 < array1.Length && index2 < array2.Length)
        {
            if (array1[index1] < array2[index2])
                target[index++] = array1[index1++];
            else
                target[index++] = array2[index2++];
        }

        while (index1 < array1.Length)
            target[index++] = array1[index1++];

        while (index2 < array2.Length)
            target[index++] = array2[index2++];

        return target;
    }
}
