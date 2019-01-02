public class Solution {
    // wrapper function
    public int Search(int[] nums, int target)
    {
        if(nums.Length ==0)
            return -1;

        return Search(nums, 0,nums.Length - 1,target);
    }

    // utility method
    private int Search(int[] nums, int lo, int hi, int target)
    {
        var mid = (lo+ hi)/2;
        if(nums[mid]== target)
            return mid;

        if(hi < lo)
            return -1;


        if(nums[lo] <= nums[mid])// left side is ordered
        {
            if( target >= nums[lo] && target <= nums[mid])
                return Search(nums, lo, mid, target);// search left
            else
                return Search(nums, mid + 1, hi, target);// search right
        }
        else if(nums[lo] > nums[mid])// right side is ordered
        {
            if( target >= nums[mid + 1] && target <= nums[hi])
                return Search(nums, mid + 1, hi, target);// search right
            else
                return Search(nums, lo, mid, target);// search left
        }
        return -1;

    }
}