

using System;
using System.Diagnostics;
namespace DataStructures
{
    public class ResizingStack<T>
    {
        private T[] a;
        private int n = 0;// variable naming is important.Leave out i,j and k for "for"loops.
        //use a descriptive name for variable but it should not be too long.
        public ResizingStack()
        {
            n = 0;
            a = new T[1];
        }
        public void push(T v)
        {
            if (n == a.Length - 1)
            {
                int length = a.Length;
                resize(2 * length);
                Debug.Assert(a.Length == 2* length);

            }
            a[n] = v;
            n++;
        }

        public int size()
        {
            return n;
        }
        public bool isEmpty()
        {
            return n == 0;
        }
        public T pop()
        {
            T item;
            if (isEmpty())
                throw new Exception("Stack is empty!");
            if (n < a.Length / 4)
            {
                resize(a.Length / 2);
            }
            item = a[--n];
            return item;
        }

        private void resize(int l)
        {
            var t = new T[l];
            for (int i = 0; i < n; i++)
                {
                    t[i] = a[i];
                }

            a = t;
        }
    }
    public class Stack<T>
    {
        private class Node
        {
            public T data;
            public Node next;
        }

        private Node top;
        private int n;
        public void push(T v)
        {
            var oldF = top;
            top = new Node();
            top.data = v;
            top.next = oldF;
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
            n--;
            return item;
        }
        public int size()
        { return n; }
    }



}