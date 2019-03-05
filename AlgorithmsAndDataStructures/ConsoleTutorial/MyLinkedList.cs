using System.Collections;



namespace DataStructuresAndAlgorithms
{
    

    class MyLinkedList<T> : IEnumerable
    {
        //Сам список. Реализует интерфейс IEnumeravle, шоб можно было форычём ходить
        public int Length { get; set; } 
        private Node<T> head; //первый элемент списка
        private Node<T> tail; //последний элемент

       

        public void Add(T value)
        {
            //Добавление элемента в список. 
            Node<T> newNode = new Node<T>();
            newNode.Value = value;

            if (head==null)
            {
                
                head = newNode;
                tail = newNode;
                
                
            }
            else
            {
                
                tail.Next = newNode; 
                tail = newNode; 
            }
            Length++; 
        }

        public void Remove(T item)
        {
            //Удаление элемента. Проверяются следующие варианты:
            // 1: Пустой список: ничего не делать.
            // 2: Один элемент: установить Previous = null.
            // 3: Несколько элементов:
            //    a: Удаляемый элемент первый.
            //    b: Удаляемый элемент в середине или конце.

            Node<T> previous = null; 
            Node<T> current = head; 

            while(current!=null)  
            {
                if(current.Value.Equals(item)) 
                {
                    if (previous!=null) 
                    {
                        previous.Next = current.Next;

                        if(current.Next==null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    Length--;
                    
                }

                previous = current; 
                current = current.Next;
            }

            
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




    }
}
