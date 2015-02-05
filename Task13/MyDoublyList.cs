using System;
using System.Collections.Generic;
using System.Collections;

namespace Task13
{
    [Serializable]
    public class MyDoublyList<T>: ICollection<T>
    {
        private MyListNode<T> first;
        private MyListNode<T> current;
        private MyListNode<T> last;
        private int size;

        public MyDoublyList()
        {
            first = null;
            current = null;
            last = null;
            size = 0;
        }

        public void Add(MyListNode<T> item) //додати вказаний елемент(вузол) в кінець колекції
        {
            if (first == null)
            {
                first = last = item;
            }
            else
            {
                last.Next = item;
                item.Previous = last;
                last = item;
            }
            size++;
        }

        public void Add(T item) //додати новий елемент в кінець колекції
        {
            var newItem = new MyListNode<T>(item);
            if (first == null)
            {
                first = last = newItem;
            }
            else
            {
                last.Next = newItem;
                newItem.Previous = last;
                last = newItem;
            }
            size++;
        }

        public void AddFirst(T item) //додати елемент на початок колекції
        {
            var newItem = new MyListNode<T>(item);
            if (first == null)
            {
                first = last = newItem;
            }
            else
            {
                newItem.Next = first;
                first = newItem;
                newItem.Next.Previous = first;
            }
            size++;
        }

        public void AddLast(T item) //додати елемент в кінець колекції
        {
            Add(item);
        }

        public void AddAfter(MyListNode<T> item, T newItem) //додати новий елемент після уже існуючного
        {
            current = item;
            var newNode = new MyListNode<T>(newItem);
            current.Next.Previous = newNode;
            newNode.Next = current.Next;
            current.Next = newNode;
            newNode.Previous = current;
            size++;
        }

        public void AddBefore(MyListNode<T> item, T newItem) //додати новий елемент перед уже існуючним
        {
            current = item;
            var newNode = new MyListNode<T>(newItem);
            current.Previous.Next = newNode;
            newNode.Previous = current.Previous;
            current.Previous = newNode;
            newNode.Next = current;
            size++;
        }

        public MyListNode<T> FindNode(T item) //знайти елемент
        {
            var findItem = new MyListNode<T>(item); 
            current = first;
            while (current != null)
            {
                if (current.Value.Equals(findItem.Value))
                {
                    return current;
                }
                current = current.Next;
            }
            return current;
        }

        public void Clear() //очистити елемент
        {
            while(current!=null)
            {
               RemoveFirst();
            }
        }

        public bool Contains(T item) //перевірити чи є в колекції вказаний елемент
        {
            var findItem = FindNode(item);
            var temp = new MyListNode<T>(item);
            if(temp.Value.Equals(findItem.Value))
            {
                return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var list = new MyListNode<T>[size];
            int i = 0;
            current = first;
            while (current != null)
            {
                list[i] = current;
                current = current.Next;
                i++;
            }
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return size; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item) //видалити перше входження вказаного елементу
        {
            var temp = new MyListNode<T>(item);
            current = first;
            if (first == null)
            {
                throw new InvalidOperationException();
            }
            while(current!=null)
            {
                if (current.Value.Equals(temp.Value))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }
                current = current.Next;
            }
            size--;
            return true;
        }

        public bool RemoveFirst() //видалити перший елемент
        {
            if (first == null)
            {
                throw new InvalidOperationException();
            }
            if (first.Next != null)
            {
                first.Next.Previous = null;
            }
            first = first.Next;
            size--;
            return true;
        }

        public bool RemoveLast() // видалити останній елемент
        {
            if (last == null)
            {
                throw new InvalidOperationException();
            }
            if (last.Previous != null)
            {
                last.Previous.Next = null;
            }
            last = last.Previous;
            size--;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var array = new T[size];
            int i = 0;
            current = first;
            while (current != null)
            {
                array[i] = current.Value;
                current = current.Next;
                i++;
            }
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
