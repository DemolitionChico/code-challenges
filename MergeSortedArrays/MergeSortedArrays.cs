namespace MergeSortedArrays;

public static class ArrayMerger
{
    public static T[] Merge<T>(T[] a, T[] b)
    where T : IComparable
    {
        T[] result = new T[a.Length + b.Length];
        int x = 0, i = 0, j = 0;
        while (true)
        {
            if ((i > a.Length - 1 && j > b.Length - 1) || x > a.Length + b.Length - 1)
            {
                break;
            }
            
            if (i >= a.Length)
            {
                result[x++] = b[j++];
                continue;
            }

            if (j >= b.Length)
            {
                result[x++] = a[i++];
                continue;
            }
            
            result[x++] = a[i].CompareTo(b[j]) < 0 ? a[i++] : b[j++];
        }
        return result;
    }
}