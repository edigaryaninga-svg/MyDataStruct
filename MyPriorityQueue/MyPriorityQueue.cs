using MyLinkedListProj;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyPriorityQueue
{
    public class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private MyLinkedList<T> _items = new MyLinkedList<T>();

        public int Count => _items.Count;

        public void Dequeue(T item)
        {
            if (_items.Count == 0)
            {
                _items.AddLast(item);
                return;
            }

            var current = _items.Head;

            while (current != null && current.Value.CompareTo(item) > 0)
            {
                current = current.Next;
            }

            if (current == null)
            {
                _items.AddLast(item);
            }
            else
            {
                _items.AddBefore(current, item);
            }
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T value = _items.Head.Value;
            _items.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _items.Head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
