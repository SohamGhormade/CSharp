
/* find a ,b,c such that a+ b+ c =0

Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0?
Find all unique triplets in the array which gives the sum of zero.

Note:

The solution set must not contain duplicate triplets.

Example:

Given array nums = [-1, 0, 1, 2, -1, -4],

A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]*/
using System;
using System.Collections.Generic;

public class ThreeSumSolution {
    public IList<IList<int>> ThreeSum(int[] nums) {

    List<IList<int>> res = new List<IList<int>>();
        // N log N per MSDN https://docs.microsoft.com/en-us/dotnet/api/system.array.sort?view=netframework-4.7.2
    Array.Sort(nums);

    for (int i = 0; i + 2 < nums.Length; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1])
        {              // skip same result
            continue;
        }
       // two pointers for b and c
        int j = i + 1, k = nums.Length - 1;
        // complement of total (0) - a
        int target = -nums[i];
        while (j < k) {
            if (nums[j] + nums[k] == target) {
                var temp = new List<int>(){nums[i], nums[j], nums[k]};
// you can add list in place of an ilist
                res.Add(temp);
                j++;
                k--;
                while (j < k && nums[j] == nums[j - 1]) j++;  // skip same result
                while (j < k && nums[k] == nums[k + 1]) k--;  // skip same result
            } else if (nums[j] + nums[k] > target) {
                k--;
            } else {
                j++;
            }
        }
    }
    return res;
}
}
