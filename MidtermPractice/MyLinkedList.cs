using System;

namespace MidtermPractice
{
    public abstract class MyLinkedListNode<T>
    {
        public readonly T value;
        public MyLinkedListNode<T> prev;
        public MyLinkedListNode<T> next;

        protected MyLinkedListNode(T value)
        {
            this.value = value;
        }
        
        
    }
    
        public class MyLinkedList<T>
    {
        private MyLinkedListNode<T> head;
        private MyLinkedListNode<T> tail;

        public MyLinkedListNode<T> Search(T value)
        {
            MyLinkedListNode<T> iterator = head;
            while (iterator!=null)
            {
                if (head.value.Equals(value))
                {
                    return iterator;
                }
                else
                {
                    iterator = iterator.next;
                }                    
            }

            return null;
        }

        public void Insert(MyLinkedListNode<T> newNode)
        {
            if (head == null && tail == null)
            {
                if (head == null)
                {
                    head = newNode;
                }

                if (tail == null)
                {
                    tail = newNode;
                }
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                newNode.next = null;
                tail = newNode;
            }
            
           
        }

        public void Delete(MyLinkedListNode<T> nodeToDelete)
        {
            MyLinkedListNode<T> iterator = head;
            while (iterator != null)
            {

                if (iterator == nodeToDelete)
                {

                    MyLinkedListNode<T> prevNode = iterator.prev;
                    MyLinkedListNode<T> nextNode = iterator.next;

                    if (prevNode != null)
                    {
                        prevNode.next = nextNode;                        
                    }
                    else
                    {
                        head = iterator.next;
                    }

                    if (nextNode != null)
                    {
                        nextNode.prev = prevNode;                        
                    }
                    else
                    {
                        tail = iterator.prev;
                    }
                }
                iterator = iterator.next;
            }
        }

        public void Reverse()
        {


            if (head == null && tail == null)
            {
                return;
            }
            MyLinkedListNode<T> headAfterReverse = tail;

            
            MyLinkedListNode<T> iteratorForOldTail = tail;
            MyLinkedListNode<T> iteratorForNewHead = headAfterReverse;
            

            
            while (iteratorForOldTail.prev!=null)
            {
                iteratorForNewHead.next = iteratorForOldTail.prev;
                iteratorForOldTail.prev.next = null;
                iteratorForOldTail = iteratorForOldTail.prev;
                iteratorForNewHead = iteratorForNewHead.next;
            }

            headAfterReverse.prev = null;
 
            iteratorForNewHead = headAfterReverse;
            MyLinkedListNode<T> iteratorForNewHeadPrev = headAfterReverse;

            while (iteratorForNewHead.next != null)
            {
                iteratorForNewHead = iteratorForNewHead.next;
                iteratorForNewHead.prev = iteratorForNewHeadPrev;
                iteratorForNewHeadPrev = iteratorForNewHead;

            }

            tail = iteratorForNewHead;
            head = headAfterReverse;

        }

        public void Print()
        {
            MyLinkedListNode<T> iterator = head;
            while (iterator != null)
            {
                Console.Write(iterator.value+" ");
                iterator = iterator.next;
            }
            
        }
    }

}