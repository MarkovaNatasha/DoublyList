using System;

namespace Task13
{
    [Serializable]
    public class MyListNode<T>
    {
        private T item;
        private MyListNode<T> next;
        private MyListNode<T> previous;
        
        public T Value
        {
            get { return item; }
            set { item = value; }
        }
        public MyListNode(T data)
        {
            item = data;
        }
        public MyListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        public MyListNode<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }
    }
}
