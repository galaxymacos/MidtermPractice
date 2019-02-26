using System;

namespace MidtermPractice
{
    public class MyQueue<T> where T : new()
    {
        private T[] arr;
        private int head;
        private int tail;
        private int elementNum = 0;

        public MyQueue()
        {
            head = -1;
            arr = new T[5];
            tail = -1;
        }
        public void EnQueue(T element)
        {
            if (!isFull())
            {
                if (head == -1 && tail == -1)    // Initialize
                {
                    tail = 0;
                }
                head = (head + 1)%arr.Length;
                arr[head] = element;
                elementNum += 1;
            }
            else
            {
                Console.WriteLine("Queue is full");
            }
        }

        public T DeQueue()
        {
            if (!Empty())
            {
                elementNum -= 1;
                T returnElement = arr[tail];
                tail = (tail + 1) % arr.Length;
                return returnElement;
            }
            else
            {
                Console.WriteLine("Queue is empty");
                return new T();
            }
        }

        public bool Empty()
        {

            return elementNum == 0;
        }

        public bool isFull()
        {
            return elementNum >= arr.Length;
        }

        public void print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }

            Console.Write(head+" "+tail);

            Console.WriteLine();
        }
    }
}