namespace MySelectionSortProj;

public class MySelectionSort<T>
    where T : IComparable<T>
{
    public void Sort(T[] items)
    {
        for (int i = 0; i < items.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < items.Length; j++)
            {
                if (Compare(items[j], items[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                Swap(items, i, minIndex);
            }
        }
    }

    private void Swap(T[] items, int a, int b)
    {
        T temp = items[a];
        items[a] = items[b];
        items[b] = temp;
    }

    private int Compare(T t1, T t2)
    {
        return t1.CompareTo(t2);
    }
}