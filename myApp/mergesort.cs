using System;
namespace Algorithms
{
    public class Sorting
    {
        public void mergesort(int[] a)
        {
            var helper = new int[a.Length];
            mergesort(a, helper, 0, a.Length - 1);

        }
        private void mergesort(int[] a, int[] helper, int l, int h)
        {
            if (l < h)
            {
                var mid = (l + h) / 2;
                mergesort(a, helper, l, mid);//sort the first half
                mergesort(a, helper, mid + 1, h);// sort the second half
                merge(a, helper, l, mid, h);

            }


        }
        private void merge(int[] a, int[] helper, int l, int m, int h)

        {
            for (int i = l; i <= h; i++)
            {
                helper[i] = a[i];
            }
            var hL = l;
            var hR = m + 1;
            var curr = l;
            while (hL <= m && hR <= h)
            {
                if (helper[hL] <= helper[hR])
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

            //copy over remaining elements if any
            var rem = m - hL;
            for (int i = 0; i <= rem; i++)
            {
                a[curr + i] = helper[hL + i];
            }

        }

    }
}