using System;


namespace DataStructuresAndAlgorithms
{

    class Sort
    {
        
       
        public Sort() //передаём массив с элементами для сортировки и тип сортировки 1-3.
        {

            Console.WriteLine("Input elements of the Array separated by spaces:");
            string[] input = Console.ReadLine().Split(' ');
            int[] A = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                A[i] = Convert.ToInt32(input[i]);
            }
            Console.WriteLine("\nWhich type of Sort do you prefer?\n1 - Insertion Sort\n2 - Bubble Sort\n3 - Quick Sort\n");
            int sortType = Convert.ToInt32(Console.ReadLine());



            switch (sortType)
            {
                case 1:
                    InsertionSort(ref A);
                    break;

                case 2:
                    BubbleSort(ref A);
                    break;

                case 3:
                    Quicksort(ref A,A.GetLowerBound(0),A.GetUpperBound(0));
                    break;

            }

            Console.WriteLine("\nThe sorted Array:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0} ", A[i]);
            }

        }
        void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        public void InsertionSort(ref int[] A) 
        {
            
            for (int i = 1; i < A.Length; i++)
            {
                int j = i;
                while (j > 0 && A[j] < A[j - 1]) //A[j] < A[j - 1]
                {
                    Swap(ref A[j], ref A[j - 1]);
                    j = j - 1;
                }
            }
        }

        public void BubbleSort(ref int[] A) 
        {
            for (int i = A.Length-1;i>=1;i--)
            {
                for (int j = 0;j<i-1;j++)
                {
                    if (A[j] > A[j + 1])/*(A[j]>A[j+1])*/
                    {
                        Swap(ref A[j], ref A[j + 1]);
                    }
                }
            }
        }

        private int Partition(int[] array, int start, int end) 
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end]) /*(array[i] < array[end]) *///array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        public void Quicksort(ref int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(array, start, end);
            Quicksort(ref array, start, pivot - 1);
            Quicksort(ref array, pivot + 1, end);
        }
    }
}
