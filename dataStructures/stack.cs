using System;
// Implement stack in C#.
// 9 mins whiteboard
// 4 mins code

// 8 mins whiteboard
// 5 mins code
public class Stack<T>
{
    private int n;
    public class Node
    {
        public T data;
        public Node next;
    }
    // Remember:
    //in C# you cannot use struct for defining a Node.
    // This is because C#structs do not allow self referential structs.
    // Basically you cannot refer to a struct in  a struct itself.
    // you need to define a class instead.
    // Note that C and C++ on the other hand,expose pointers.
    // So structs can be self referential in C and C++
    private Node t;
    //O(1)
    public void push(T v)
    {
        var q = new Node();
        q.data = v;
        if (t == null)
            t = q;
        else
        {
            var oldT = t;
            t = q;
            t.next = oldT;

        }
        n++;
    }
    //O(1)
    public T pop()
    {
        if (isEmpty()) throw new Exception("No elements to remove!");

        var i = t.data;
        t = t.next;
        n--;
        return i;
    }
    public T peek()
    {
        if (isEmpty()) throw new Exception("No elements to remove!");
        return t.data;
    }
    public int size()
    {
        return n;
    }
    public bool isEmpty()
    {
        return n == 0;
    }


}
class MyStack<T>
{
    private int n;
    private T[] a = new T[1];

    private void resize(int size)
    {
        var t = new T[size];
        // Use System Array Copy
        var l =a.Length < size ? a.Length : size;
        for (int i = 0; i < l; i++)
        {
            t[i] = a[i];
        }
        a = t;

    }
    // O(1)
    public void push(T v)
    {
        if (n == a.Length)
            resize(2 * n);

        a[n++] = v;
    }

    public T pop()
    {
         if (isEmpty()) throw new Exception("No elements to remove!");// TODO :resizing stack can be empty too.
         // throw exception in this case.
        if (n < a.Length / 4)
            resize(a.Length / 2);

        var i = a[--n];
        a[n] = default(T);
        return i;
    }

    public int size()
    {
        return n;

    }
    public bool isEmpty()
    {
        return n == 0;
    }
}
