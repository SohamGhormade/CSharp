
using System;
// Copied C++ solution from Discussion(https://leetcode.com/problems/maximum-product-subarray/discuss/48230/Possibly-simplest-solution-with-O(n)-time-complexity)
//and converted to C#
public class MaxProduct_Solution
{
    public int MaxProduct(int[] nums)
    {
      var maxProduct = nums[0];
      var currentMax =  maxProduct;
      var currentMin =  maxProduct;
      for (var i = 1; i < nums.Length; i++)
    {
        // multiplied by a negative makes big number smaller, small number bigger
        // so we redefine the extremums by swapping them
        if (nums[i] < 0)
        {
            var temp = currentMax;
            currentMax = currentMin;
            currentMin = temp;
        }

        currentMax = Math.Max(nums[i], currentMax * nums[i]);
        currentMin = Math.Min(nums[i], currentMin * nums[i]);

        maxProduct = Math.Max(maxProduct, currentMax);
    }
    return maxProduct;
}
}