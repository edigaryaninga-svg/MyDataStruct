using System;
using System.Collections;
using System.Collections.Generic;
using MyLinkedListProj; 

namespace MyQueueProj
{
    public class MyQueue<T> : IEnumerable<T>
    {
       
        private MyLinkedList<T> _items = new MyLinkedList<T>();

        public void Enqueue(T value)
        {
            _items.AddLast(value);
        }

        public T Dequeue()
        {
            if (_items.Count == 0) return default(T);

          
            T value = _items.Head.Value;
            _items.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_items.Head == null) return default(T);
            return _items.Head.Value;
        }

        public int Count => _items.Count;

        public void Clear() => _items.Clear();

        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}