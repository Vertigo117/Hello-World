﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    class Stack<T>
    {
        

        MyDoubleLinkedList<T> items = new MyDoubleLinkedList<T>();

        public void Push(T value)
        {
            items.Add(value);
        }

        public T Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T result = items.Tail.Value;
            items.RemoveLast();
            return result;
        }

        public T Peek()
        {
            if(items.Length==0)
            {
                throw new InvalidOperationException("The stack is empty");
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
