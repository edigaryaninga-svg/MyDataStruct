using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedListProj
{
    public class MyLinkedList<T> : ICollection<T>
    {
      
        public MyLinkedListNode<T>? Head { get; private set; }
        public MyLinkedListNode<T>? Tail { get; private set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public MyLinkedList() { }

        #region Add Methods

        public void AddFirst(T value)
        {
            var newNode = new MyLinkedListNode<T>(value);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            var newNode = new MyLinkedListNode<T>(value);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
            
                if (Tail != null)
                {
                    Tail.Next = newNode;
                }
                Tail = newNode;
            }
            Count++;
        }

        public void AddBefore(MyLinkedListNode<T> targetNode, T item)
        {
            if (targetNode == null)
                throw new ArgumentNullException(nameof(targetNode));

            if (targetNode == Head)
            {
                AddFirst(item);
                return;
            }

            var newNode = new MyLinkedListNode<T>(item);
            var current = Head;

            while (current != null && current.Next != targetNode)
            {
                current = current.Next;
            }

            if (current == null)
                throw new InvalidOperationException("Node not found.");

            newNode.Next = targetNode;
            current.Next = newNode;

            Count++;
        }

        #endregion

        #region Remove Methods

        public void RemoveFirst()
        {
            if (Head == null) return;

            Head = Head.Next;
            Count--;

            if (Count == 0)
            {
                Tail = null;
            }
        }

        public void RemoveLast()
        {
            if (Head == null) return;

            if (Head == Tail)
            {
                Head = Tail = null;
            }
            else
            {
                var temp = Head;
            
                while (temp != null && temp.Next != Tail)
                {
                    temp = temp.Next;
                }

                if (temp != null)
                {
                    temp.Next = null;
                    Tail = temp;
                }
            }
            Count--;
        }

        #endregion

        #region Helpers & Enumerator

        public void Add(T item) => AddLast(item);

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value != null && current.Value.Equals(item)) return true;
                current = current.Next;
            }
            return false;
        }

        public bool Remove(T item) => throw new NotImplementedException();

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
