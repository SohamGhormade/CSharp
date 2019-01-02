using System;
using System.Diagnostics;

// Implement a max size heap in C#.
// 23 mins whiteboard
// 13 mins code
//13 mins test.
//wokrs fine.
public class Heap<T> where T : IComparable
{

    private int n;// size of the heap
    private T[] a;

    // bottom up reheapify
    private void swim(int k)
    {
        while (k > 1 && a[k].CompareTo(a[k / 2]) > 0)
        {
            swap(k, k / 2);
            k = k / 2;

        }
    }

    // top down reheapify
    private void sink(int k)
    {
        int child = 0;//
        // declared outside while loop so that its value is preserved across consecutive iterations
        while (k < n)
        {
            child = 2 * k;
            if (a[child].CompareTo(a[child + 1])< 0) child++;
            if (a[child].CompareTo(a[k]) > 0)
                swap(child, k);
            k = child;
        }
    }

    private void swap(int i, int j)
    {
        var t = a[i];
        a[i] = a[j];
        a[j] = t;
    }

    public Heap()
    {
        a = new T[1000];// can use resizing array if needed
        a[0] = default(T);//sentinel value
    }

    public int size()
    {
        return n;
    }
    public bool isEmpty()
    {
        return n == 0;
    }
    public void insert(T value)
    {
        a[++n] = value;
        swim(n);
    }

    public T delMax()
    {
        var max = a[1];
        swap(1, --n);
        a[n] = default(T);//avoid loitering

        sink(1);
        return max;
    }

    public T peek()
    {
        return a[1];
    }

}

public class HeapTest
{
    public void test()
    {
        var heap = new Heap<int>();
        Debug.Assert(heap.isEmpty());
        heap.insert(10);
        Debug.Assert(!heap.isEmpty());
        Debug.Assert(1 == heap.size());
        Debug.Assert(10 == heap.peek());

        heap.insert(7);
        Debug.Assert(10 == heap.peek());
        Debug.Assert(2 == heap.size());

        heap.insert(5);
        Debug.Assert(10 == heap.peek());
        Debug.Assert(3 == heap.size());

        heap.insert(34);
        Debug.Assert(34 == heap.peek());
        Debug.Assert(4 == heap.size());

        heap.insert(12);
        Debug.Assert(34 == heap.peek());
        Debug.Assert(5 == heap.size());

        heap.insert(120);
        Debug.Assert(120 == heap.peek());
        Debug.Assert(6 == heap.size());

        heap.insert(23);
        Debug.Assert(120 == heap.peek());
        Debug.Assert(7 == heap.size());

        Debug.Assert(120 == heap.delMax());
         Debug.Assert(34 == heap.delMax());
    }
}