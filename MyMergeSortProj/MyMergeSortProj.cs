using System;

namespace MyMergeSortProj
{
    public class MergeSort<T> where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            if (items.Length <= 1) return;

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;

            T[] left = new T[leftSize];
            T[] right = new T[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            Sort(left);
            Sort(right);
            Merge(items, left, right);
        }

        private void Merge(T[] items, T[] left, T[] right)
        {
            int leftIndex = 0, rightIndex = 0, targetIndex = 0;
            int remaining = left.Length + right.Length;

            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    Assign(items, targetIndex, right[rightIndex++]);
                }
                else if (rightIndex >= right.Length)
                {
                    Assign(items, targetIndex, left[leftIndex++]);
                }
                else if (Compare(left[leftIndex], right[rightIndex]) < 0)
                {
                    Assign(items, targetIndex, left[leftIndex++]);
                }
                else
                {
                    Assign(items, targetIndex, right[rightIndex++]);
                }
                targetIndex++;
                remaining--;
            }
        }

        private int Compare(T t1, T t2)
        {
            return t1.CompareTo(t2);
        }

        private void Assign(T[] items, int targetIndex, T value)
        {
            items[targetIndex] = value;
        }
    }
}