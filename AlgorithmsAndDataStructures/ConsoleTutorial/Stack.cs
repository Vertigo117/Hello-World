using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTutorial
{
    class Stack<T>
    {
        int index = 0;
        T[] innerArray = new T[100];
        
        public void Push(T item)
        {
            innerArray[index++] = item;
        }

        public T Pop()
        {
            return innerArray[--index];
        }

        public T Get(int k)
        {
            return innerArray[k];
        }
    }
}
