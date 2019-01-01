// Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.

// Example 1:

// Input: [2,3,-2,4]
// Output: 6
// Explanation: [2,3] has the largest product 6.
// Example 2:

// Input: [-2,0,-1]
// Output: 0
// Explanation: The result cannot be 2, because [-2,-1] is not a subarray.

using System;

public class Solution_MaxProductSubArray
{
    public int MaxProduct(int[] nums)
    {
        // store the result that is the max we have found so far
        int r = nums[0];

        // currentMax/currentMin stores the max/min product of
        // subarray that ends with the current number nums[i]
        for (int i = 1, currentMax = r, currentMin = r; i < nums.Length; i++)
        {
            // multiplied by a negative makes big number smaller, small number bigger
            // e.g (max, min) = (100, 1)
              //(-max, - min)=(-1, -100) // the values of min and max are swapped
            // so we redefine the extremums by swapping them
            if (nums[i] < 0)
                swap(nums,currentMax, currentMin);

            // max/min product for the current number is either the current number itself
            // or the max/min by the previous number times the current one
            currentMax = Math.Max(nums[i], currentMax * nums[i]);
            currentMin = Math.Min(nums[i], currentMin * nums[i]);

            // the newly computed max value is a candidate for our global result
            r = Math.Max(r, currentMax);
        }
        return r;
    }

    private void swap(int[] a,int currentMax, int currentMin)
    {
       var temp = a[currentMax];
       a[currentMin] = a[currentMax];
       a[currentMin] = temp;
    }
}
