using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    class MyQueue<T>
    {
        MyDoubleLinkedList<T> items = new MyDoubleLinkedList<T>();

        public void Enqueue(T value)
        {
            items.AddFirst(value);
        }

        public T Dequeue()
        {
            if(items.Length==0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T last = items.Tail.Value;
            items.RemoveLast();
            return last;
        }

        public T Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return items.Tail.Value;
        }

        public int Count
        {
            get
            {
                return items.Length;
            }
        }
    }
}
