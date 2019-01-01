using System;
namespace Algorithms
{
    public class MergeSort
    {
        //wrapper method
        public void sort(int[] a)
        {
            var helper = new int[a.Length];//Space O(N)
            sort(a, helper, 0, a.Length - 1);
        }
        private void sort(int[] a, int[] helper, int low, int high)
        {
            if (low < high)
            {
                //divide
                var mid = (low + high) / 2;
                sort(a, helper, low, mid);
                sort(a, helper, mid + 1, high);
                merge(a, helper, low, mid, high);
            }
        }

        private void merge(int[] a, int[] helper, int low, int mid, int high)
        {
            //copy over a into helper
            for (int i = low; i <= high; i++)
                helper[i] = a[i];

            var hL = low;
            var hR = mid + 1;
            var curr = low;
            while (hL <= mid && hR <= high)
            {
                if (helper[hL] < helper[hR])
                {
                    a[curr] = helper[hL];
                    hL++;
                }
                else
                {
                    a[curr] = helper[hR];
                    hR++;
                }
                curr++;
            }
            var rem = mid - hL;
            for (int i = 0; i <= rem; i++)
            {
                a[curr + i] = helper[hL + i];
            }
        }
    }
}