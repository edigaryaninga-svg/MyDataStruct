using System;

namespace BinaryTreeProj
{
    public class MyBinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        public T Value { get; set; }
          
        public MyBinaryTreeNode<T>? Left { get; set; }
        public MyBinaryTreeNode<T>? Right { get; set; }

        public MyBinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public int CompareTo(T? other)
        {
            if (other == null) return 1;
            return Value.CompareTo(other);
        }
    }
}