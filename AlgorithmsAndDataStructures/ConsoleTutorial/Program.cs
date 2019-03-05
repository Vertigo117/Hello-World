using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTutorial
{

    class Program
    {
        
       
        static void Main(string[] args)
        {
            //Sort s = new Sort();
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Remove(5);

            foreach (var i in list)
            {
                Console.Write("{0} ", i);
            }




            Console.ReadKey();


        }
    }
}
