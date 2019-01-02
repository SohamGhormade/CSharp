using System;

//Implement linked list in C#.
// 9 mins
// 15 mins on whiteboard
public class LinkedList<T>
{
    private Node f,l;//first and last nodes
    private int n;//TODO make sure that all variables are used especially count variable.

    private class Node
    {
        public T data;
        public Node next;
    }

// O(1)
   public bool isEmpty()// TODO check method signature before submitting
  {
    return n==0;
  }
//O(1)
    public int size()
    {
        return n;
    }
    //O(1)
    public void insertAtBeg(T v)
    {
        var oldF = f;
        f = new Node();
        f.data = v;
        if(oldF ==null)
        {
            l = f;
        }
        else
         f.next = oldF;

         n++;

    }
//O(1)
    public void insertAtEnd(T v)
    {
        var oldL = l;
        l = new Node();
        l.data = v;
        if(oldL == null)
        {
            f = l;

        }
        else
        {
            oldL.next = l;
        }
        n++;
    }
//O(1)
    public T removeAtBeg()
    {
        if(isEmpty()) throw new Exception("No elements left to remove.The list is empty.Add elements before you can remove them.");

        var item = f.data;
        f = f.next;
        n--;
        return item;

    }
//O(n)
public T removeAtEnd()
{
      if(isEmpty()) throw new Exception("No elements left to remove.The list is empty.Add elements before you can remove them.");

      var item = l.data;
    var q = f;
    while(q.next !=l)
    {
        q = q.next;
    }
    l = q;
    n--;
    return item;
}
}
