namespace MyQuickSortProject;

public class MyQuickSort<T> where T : IComparable<T>
{
    public void QuickSort(T[] items)
    {
        Sort(items, 0, items.Length - 1);
    }

    private void Sort(T[] items, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(items, low, high);

            Sort(items, low, pivotIndex - 1);
            Sort(items, pivotIndex + 1, high);
        }
    }

    private int Partition(T[] items, int low, int high)
    {
        T pivot = items[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (Compare(items[j], pivot) <= 0)
            {
                i++;
                Swap(items, i, j);
            }
        }

        Swap(items, i + 1, high);
        return i + 1;
    }

    private int Compare(T t1, T t2)
    {
        return t1.CompareTo(t2);
    }

    private void Swap(T[] items, int i, int j)
    {
        T temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }
}
