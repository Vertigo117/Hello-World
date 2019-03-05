using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    
    class MyDoubleLinkedList<T> : IEnumerable
    {
        //Сам список. Реализует интерфейс IEnumeravle, шоб можно было форычём ходить
        public int Length { get; set; }
        private Node<T> head; //первый элемент списка
        private Node<T> tail; //последний элемент



        public void Add(T value)
        {
            AddLast(value);
        }

        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = head;

            // 1: Пустой список: ничего не делать.
            // 2: Один элемент: установить Previous = null.
            // 3: Несколько элементов:
            //    a: Удаляемый элемент первый.
            //    b: Удаляемый элемент в середине или конце.

            while (current != null)
            {
                // Head -> 3 -> 5 -> 7 -> null
                // Head -> 3 ------> 7 -> null
                if (current.Value.Equals(item))
                {
                    // Узел в середине или в конце.
                    if (previous != null)
                    {
                        // Случай 3b.
                        previous.Next = current.Next;

                        // Если в конце, то меняем _tail.
                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                        else
                        {
                            // До:    Head -> 3  5  7 -> null
                            // После: Head -> 3  7 -> null

                            // previous = 3
                            // current = 5
                            // current.Next = 7
                            // Значит... 7.Previous = 3
                            current.Next.Previous = previous;
                        }

                        Length--;
                    }
                    else
                    {
                        // Случай 2 или 3a.
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            //Полная очистка списка
            head = null;
            tail = null;
            Length = 0;
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            //Реализация метода GetEnumerator из интерфейса IEnumerable. Не совсем понимаю, как работает yield.
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;

            // Сохраняем ссылку на первый элемент.
            Node<T> temp = head;

            // _head указывает на новый узел.
            head = node;

            // Вставляем список позади первого элемента.
            head.Next = temp;

            if (Length == 0)
            {
                // Если список был пуст, то head and tail должны
                // указывать на новой узел.
                tail = head;
            }
            else
            {
                // До:    head -------> 5  7 -> null
                // После: head  -> 3  5  7 -> null
                temp.Previous = head;
            }

            Length++;
        }

        public void AddLast(T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;

            if (Length == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node;

                // До:    Head -> 3  5 -> null
                // После:Head -> 3  5  7 -> null
                // 7.Previous = 5
                node.Previous = tail;
            }

            tail = node;
            Length++;
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                // До:    Head -> 3  5
                // После: Head -------> 5

                // Head -> 3 -> null
                // Head ------> null
                head = head.Next;

                Length--;

                if (Length == 0)
                {
                    tail = null;
                }
                else
                {
                    // 5.Previous было 3; теперь null.
                    head.Previous = null;
                }
            }
        }
        public void RemoveLast()
        {
            if (Length != 0)
            {
                if (Length == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    // До:    Head --> 3 --> 5 --> 7
                    //        Tail = 7
                    // После: Head --> 3 --> 5 --> null
                    //        Tail = 5
                    // Обнуляем 5.Next
                    tail.Previous.Next = null;
                    tail = tail.Previous;
                }

                Length--;
            }
        }

        public Node<T> Head
        {
            get
            {
                return head;
            }
        }

        public Node<T> Tail
        {
            get
            {
                return tail;
            }
        }


    }
}

