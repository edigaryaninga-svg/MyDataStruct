using MyBinaryTreeProj;
using MyHashTableAlgorithms;
using MyLinkedListProj;
using MyQueueProj;
using MyStackProj;
using MyPriorityQueue;
using MyBubbleSortProj;    // Ավելացված է
using MyInsertionSortProj; // Ավելացված է
using MyMergeSortProj;
using MyQuickSortProject;
using MySelectionSortProj;
using System;
using System.Collections;

namespace MyRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Հայերեն տառերի համար

            // --- 1. LINKED LIST-Ի ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 1. Linked List Test =====");
            MyLinkedList<string> list = new MyLinkedList<string>();
            list.Add("Առաջին");
            list.Add("Երկրորդ");
            foreach (var item in list) Console.WriteLine($"- {item}");
            Console.WriteLine();

            // --- 2. STACK (Linked List-based) ---
            Console.WriteLine("===== Stack Test =====");
            var s = new MyLinkedListLibrary.MyStack<int>();
            s.Push(100); s.Push(200); s.Push(300);
            Console.WriteLine($"Վերևում է (Peek): {s.Peek()}");
            Console.WriteLine($"Հեռացվեց (Pop): {s.Pop()}");
            Console.WriteLine($"Հաջորդը (Peek): {s.Peek()}");
            Console.WriteLine("\nՄնացածը ստեկում:");
            foreach (int x in s) Console.WriteLine(x);
            Console.WriteLine();

            // --- 3. STACK (ARRAY-ՈՎ) ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 2. Stack (Array-based) Test =====");
            MyStackArray<int> stack = new MyStackArray<int>();
            stack.Push(10);
            stack.Push(20);
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine();

            // --- 4. BINARY TREE-Ի ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 3. Binary Tree Test =====");
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Add(50); tree.Add(30); tree.Add(70);
            Console.Write("In-Order: ");
            foreach (var val in tree) Console.Write(val + " ");
            Console.WriteLine("\n");

            // --- 5. QUEUE (ՀԵՐԹ) ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 4. Queue Test (FIFO) =====");
            MyQueue<string> queue = new();
            queue.Enqueue("Հաճախորդ 1");
            queue.Enqueue("Հաճախորդ 2");
            Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            Console.WriteLine();

            // --- 6. HASH TABLE-Ի ՍՏՈՒԳՈՒՄ (REFLECTION-ՈՎ) ---
            Console.WriteLine("===== 5. Hash Table Test (Private Access) =====");
            try
            {
                var type = typeof(MyHashTableAlgorithms.Program);
                var method = type.GetMethod("FoldingHash",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

                if (method != null)
                {
                    string testKey = "lore";
                    var result = method.Invoke(null, new object[] { testKey });
                    Console.WriteLine($"Բանալի: {testKey}");
                    Console.WriteLine($"Folding Hash: {result}");
                    Console.WriteLine($"Ինդեքս (mod 10): {Math.Abs((int)result % 10)}");
                }
            }
            catch (Exception ex) { Console.WriteLine("Սխալ Hash Table-ում: " + ex.Message); }
            Console.WriteLine();


            // --- 8. SET (ԲԱԶՄՈՒԹՅՈՒՆ) ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 7. Set (Բազմություն) Test =====");
            MySet.MySet<int> setA = new MySet.MySet<int>();
            setA.AddRange(new int[] { 1, 2, 3 });
            MySet.MySet<int> setB = new MySet.MySet<int>();
            setB.AddRange(new int[] { 3, 4, 5 });
            Console.WriteLine("Միավորում: " + string.Join(", ", setA.Union(setB)));
            Console.WriteLine();

            // --- 9. BUBBLE SORT ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 8. Bubble Sort Test =====");
            int[] bubbleArr = { 5, 2, 8, 1, 9 };
            BubbleSort<int> bSorter = new BubbleSort<int>();
            bSorter.Sort(bubbleArr);
            Console.WriteLine("Bubble Sort-ից հետո: " + string.Join(", ", bubbleArr));
            Console.WriteLine();

            // --- 10. INSERTION SORT ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 9. Insertion Sort Test =====");
            int[] insertionArr = { 10, 3, 7, 4, 1 };
            MyInsertionSort<int> iSorter = new MyInsertionSort<int>();
            iSorter.Sort(insertionArr);
            Console.WriteLine("Insertion Sort-ից հետո: " + string.Join(", ", insertionArr));
            Console.WriteLine();

            // --- 11. MERGE SORT ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 10. Merge Sort Test =====");
            int[] mergeArr = { 38, 27, 43, 3, 9, 82, 10 };
            Console.WriteLine("Նախքան սորտավորելը: " + string.Join(", ", mergeArr));

            MergeSort<int> mSorter = new MergeSort<int>();
            mSorter.Sort(mergeArr);

            Console.WriteLine("Merge Sort-ից հետո: " + string.Join(", ", mergeArr));
            Console.WriteLine();

            // --- 12. QUICK SORT ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 11. Quick Sort Test =====");
            int[] quickArr = { 10, 80, 30, 90, 40, 50, 70 };
            Console.WriteLine("Նախքան սորտավորելը: " + string.Join(", ", quickArr));

            MyQuickSort<int> qSorter = new MyQuickSort<int>();
            qSorter.QuickSort(quickArr);

            Console.WriteLine("Quick Sort-ից հետո: " + string.Join(", ", quickArr));
            Console.WriteLine();

            // --- 13. SELECTION SORT ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 12. Selection Sort Test =====");
            int[] selectArr = { 64, 25, 12, 22, 11 };
            Console.WriteLine("Նախքան սորտավորելը: " + string.Join(", ", selectArr));

            MySelectionSort<int> sSorter = new MySelectionSort<int>();
            sSorter.Sort(selectArr);

            Console.WriteLine("Selection Sort-ից հետո: " + string.Join(", ", selectArr));
            Console.WriteLine();

            // --- ԱՎԱՐՏ ---
            Console.WriteLine("===============================");
            Console.WriteLine("Բոլոր թեստերը հաջողությամբ ավարտվեցին:");
            Console.ReadLine(); // Այստեղ այն իր տեղում է
        }
    }
}