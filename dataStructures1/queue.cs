using System;

// 9 mins whiteboard
// 5 mins code
// Implement queue in C#.
public class Queue<T>
{
    private int n;
    private class Node
    {
        public T data;
        public Node next;
    }
private Node f,l;
   public int size()
   {
       return n;
   }

   public bool isEmpty()
   {
      return n ==0;
   }

   public void enqueue(T v)
   {
       var oldL = l;
       l = new Node();
       l.data = v;
       if(oldL == null)
         f = l;
       else
         oldL.next  = l;

         n++;

   }

    public T dequeue()
    {
        if(isEmpty()) throw new Exception("No elements to remove.");

        var i = f.data;
        f = f.next;
        n--;
        return i;
    }
}