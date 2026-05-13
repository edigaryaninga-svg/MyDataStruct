namespace MyLinkedListProj
{
    public class MyLinkedListNode<T>
    {
        public T Value { get; set; }
   
        public MyLinkedListNode<T>? Next { get; set; }

        public MyLinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }
}