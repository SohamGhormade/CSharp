

using System.Diagnostics;

public class Stack<T>
{
    private class Node<T>
    {
        T data;
        Node<T> next;
    }

    private Node<T> top;
    private int n;
    public void push(T v)
    {
        var oldF = top;
        top = new Node<T>();
        top->data = v;
        top->next = oldF;
        n++;
    }

    public bool isEmpty()
    {
        return top == null;
    }
    public T pop()
    {
        T item;
        if (isEmpty())
            throw new Exception(" The stack is empty.No elements to pop!");
        else
        {

            item = top.data;
            top = top.next;

        }
        return item;
    }

}
public void main()
{
    var stack = new Stack<int>();
    Debug.Assert(stack.isEmpty());

    stack.push(8);
    Debug.Assert(!stack.isEmpty());
    Debug.Assert(1 == stack.size());

    stack.push(3);
    Debug.Assert(2 == stack.size());

    stack.push(-67);
    Debug.Assert(3== stack.size());

    Debug.Assert(-67==stack.pop());
    Debug.Assert(2 == stack.size());

    Debug.Assert(3==stack.pop());
    Debug.Assert(1 == stack.size());

    Debug.Assert(8==stack.pop());
    Debug.Assert(0 == stack.size());
    Debug.Assert(stack.isEmpty());
 try
 {
 stack.pop();
 }

 catch (System.Exception e)
 {

   Console.WriteLine("exception thrown:"+e.Message);
 }
}
