using System;

namespace MidtermPractice
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = {3, 7, 4, 2, 8, 5, 7, 1, 6, 9, 7, 0};

            QuickMergeSort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
        }

        public static void MagicSort(int[] array, int magicNumber)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var target = array[i];
                var j = i;
                while (j - 1 >= 0 && array[j - 1] != magicNumber && (array[j - 1] < target || target == magicNumber))
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = target;
                for (var k = 0; k < array.Length; k++) Console.Write(array[k] + " ");

                Console.WriteLine();
            }
        }

        public static void QuickMergeSort(int[] array)
        {
            int mid = array.Length / 2;
            
            if (mid % 2 == 0)
            {
                SortMerge(array,0,mid);
            }
            else
            {
                Quick_Sort(array,0,mid);
            }

            if ((array.Length - mid) % 2 == 0)
            {
                SortMerge(array,mid+1,array.Length-1);
            }
            else
            {
                Quick_Sort(array,mid+1,array.Length-1);
            }

            if (array.Length % 2 == 0)
            {
                SortMerge(array,0,array.Length-1);
            }
            else
            {
                Quick_Sort(array,0,array.Length-1);
            }
            
        }
        
        private static void Quick_Sort(int[] arr, int left, int right) 
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1) {
                    
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right) {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true) 
            {

                while (arr[left] < pivot) 
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else 
                {
                    return right;
                }
            }
        }
        
        private static void MainMerge(int[] numbers, int left, int mid, int right)

        {

            int[] temp = new int[25];

            int i, eol, num, pos;

 

            eol = (mid - 1);

            pos = left;

            num = (right - left + 1);

 

            while ((left <= eol) && (mid <= right))

            {

                if (numbers[left] <= numbers[mid])

                    temp[pos++] = numbers[left++];

                else

                    temp[pos++] = numbers[mid++];

            }

 

            while (left <= eol)

                temp[pos++] = numbers[left++];

 

            while (mid <= right)

                temp[pos++] = numbers[mid++];

 

            for (i = 0; i < num; i++)

            {

                numbers[right] = temp[right];

                right--;

            }

        }

 

        private static void SortMerge(int[] numbers, int left, int right)

        {
            int mid;
            if (right > left)

            {

                mid = (right + left) / 2;

                SortMerge(numbers, left, mid);

                SortMerge(numbers, (mid + 1), right);

 

                MainMerge(numbers, left, (mid + 1), right);

            }

        }
    }
}