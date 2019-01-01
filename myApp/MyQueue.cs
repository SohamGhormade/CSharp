
namespace DataStructures
{
    public class Queue<T>
    {
        private class Node
        {
            public T data;
            public Node next;
        }

        private Node f, l;// pointers to first and last elements
        private int n;// size of queue

        public bool isEmpty()
        {
            return f == null;
        }
        public void enqueue(T v)
        {
            var oldL = l;
            var t = new Node();
            t.data = v;
            t.next = oldL;

            if(isEmpty())
            {
                l = f = t;
            }
            else
            {
                l = t;
            }
            n++;
        }

        public T dequeue()
        {
            T item;
            if (isEmpty()) throw new System.Exception("No elements to delete!");
            else
            {
                item = f.data;
                f = f.next;
            }
            n--;
            return item;

        }
        public int size()
        {
            return n;
        }

    }
}