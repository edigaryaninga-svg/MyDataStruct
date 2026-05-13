using System;
using System.Collections;
using System.Collections.Generic;
using MyLinkedListProj; 

namespace MyLinkedListLibrary
{
    public class MyStack<T> : IEnumerable<T>
    {
     
        private MyLinkedList<T> _list = new MyLinkedList<T>();

        public void Push(T value) => _list.AddFirst(value);

        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack is empty");

         
            T val = _list.Head.Value;
            _list.RemoveFirst();
            return val;
        }

        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            return _list.Head.Value;
        }

        public bool IsEmpty() => _list.Count == 0;

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
