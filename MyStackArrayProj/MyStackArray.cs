using System;
using System.Collections;
using System.Collections.Generic;

namespace MyStackProj
{
    public class MyStackArray<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _top;
        private const int DefaultCapacity = 4;

        public MyStackArray()
        {
            _items = new T[DefaultCapacity];
            _top = -1;
        }

        public void Push(T item)
        {
            if (_top == _items.Length - 1)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }

            _top++;
            _items[_top] = item;
        }

        public T Pop()
        {
            if (_top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T value = _items[_top];
            _items[_top] = default(T)!;
            _top--;
            return value;
        }

        public T Peek()
        {
            if (_top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return _items[_top];
        }

        public int Count => _top + 1;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _top; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
