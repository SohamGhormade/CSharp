using System;
namespace Algorithms
{
    public class Quick
    {
        // Quick Sort
        // Average O(NLogN)
        //Worst O(N^2)
        public void sort(int[] a, int left, int right)
        {
            var index = partition(a, left, right);
            if (left < index - 1)
            {
                sort(a, left, index - 1);
            }
            if (index < right)
            {
                sort(a, index, right);
            }


        }
        //returns the index of the pivot
        private int partition(int[] a, int left, int right)
        {
            int pivot = a[(left + right) / 2];
            while (left <= right)
            {
                while(a[left] < pivot) left++;
                while (pivot < a[right]) right--;
                if (left <= right)
                {
                    swap(a, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }
        private void swap(int[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;

        }
    }
}