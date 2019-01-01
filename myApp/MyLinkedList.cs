using System;
namespace DataStructures
{
    // 20 minutes on whiteboard
    // 26 minutes on computer
    //O(1) insert and delete at start ,delete at end O(n)

    public class MyLinkedList
    {
        private class LinkedListNode
        {
            public LinkedListNode next;
            public int data;
        }
        private LinkedListNode first, last;
        private int n;//size
        public MyLinkedList()
        {
            first = last = null;

        }

        public bool isEmpty()
        {
            return first == null;
        }

        public int size()
        {
            return n;
        }

        public void insertAtBeg(int i)
        {
            var oldF = first;
            first = new LinkedListNode();
            first.data = i;
            if (oldF == null)
                last = first;
            else
                first.next = oldF;
            n++;//TODO forgot to increment and decrement size--improve on this area.Test out every function you write
            //include the small and easy ones too like size().
        }

        public void insertAtEnd(int i)
        {
            var oldL = last;
            last = new LinkedListNode();
            last.data = i;
            if (oldL == null)
            {
                first = last;
            }
            else
                oldL.next = last;
            n++;
        }

        public int removeAtBeg()
        {
            int item = Int32.MaxValue;//invalid value
            if (first != null)
            {
                item = first.data;
                first = first.next;
            }
            else
                throw new Exception("no elements to delete!");
            n--;
            return item;
        }
        public int removeAtEnd()
        {
            int item = Int32.MaxValue;//invalid value
            if (last != null)
            {
                item = last.data;
                var t = first;
                while (t.next != last)
                {
                    t = t.next;
                }
                last = t;
                last.next = null;

            }
            else
                throw new Exception("no elements to delete!");
            n--;
            return item;
        }
    }

}