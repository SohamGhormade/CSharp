using System;
using System.Diagnostics;

namespace DataStructures
{
    //Implement a max heap in C#.
    public class Heap<T> where T : IComparable
    {
        private int n;// size of the heap
        private T[] a;

        // bottom up reheapify
        private void swim(int k)
        {
            while (k > 1 && a[k / 2].CompareTo(a[k]) < 0)
            {
                swap(k, k / 2);
                k = k / 2;
            }

        }
        private void swap(int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

//TODO review
        // top down reheapify
        private void sink(int k)
        {
            // while (2 * k < n && a[k].CompareTo(a[2 * k]) < 0)
            // {
            //     swap(k, 2 * k);
            //     k = 2 * k;
            // }
               int child = 0;

                while(child <= n)
                {
                   child = 2 *k;
                   // find the bigger of the two children IMP
                   if(a[child].CompareTo(a[child + 1])<0) child++;

                    if(a[child].CompareTo(a[k])>0)
                     swap(child, k);

                     k = child;

                }
        }

        public Heap()
        {
            n = 0;
            a = new T[100];//hack,correct way is to resize
        }
        public void insert(T val)
        {
            a[++n] = val;
            swim(n);

        }
        public T deleteMax()
        {
            var r = a[1];
            swap(1, n - 1);
            sink(1);
            a[n - 1] = default(T);// avoid loitering
            n--;
            return r;
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

}