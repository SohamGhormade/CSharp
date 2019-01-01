// Given an array nums of n integers where n > 1,
// return an array output such that output[i] is equal to
// the product of all the elements of nums except nums[i].
// Example:

// Input:  [1,2,3,4]
// Output: [24,12,8,6]
// Note: Please solve it without division and in O(n).

// Follow up:
// Could you solve it with constant space complexity?
//(The output array does not count as extra space for the purpose of space complexity analysis.)


public class ArraySolution_prod
{
    public int[] productExceptSelf(int[] nums)
    {
        int[] result = new int[nums.Length];
        for (int i = 0, tmp = 1; i < nums.Length; i++)
        {
            result[i] = tmp;
            tmp *= nums[i];
        }
        for (int i = nums.Length - 1, tmp = 1; i >= 0; i--)
        {
            result[i] *= tmp;
            tmp *= nums[i];
        }
        return result;
    }

    //input : [ 1 2 3 4]
    //output :[24,12,8,6]

    // start from left side
    // step 1 : [1, 2, 3, 4]
    // result    1, 1, 2, 6
    // temp      1  2  6, 24

    // start from right side
    // step 2 : [1, 2, 3, 4]
    // result    24, 12, 4, 1 => multiply with result from step 1
    // ANS       24, 12, 8, 6
    // temp      1  24  12, 4


    public int[] ProductExceptSelf_MyAttempt(int[] nums)
    {

        var result = new int[nums.Length];
        for (int i = 0, temp = 1; i < nums.Length; i++)
        {
            result[i] = temp;
            temp *= nums[i];
        }

        for (int i = nums.Length - 1, temp = 1; i >= 0; i--)
        {
            result[i] *= temp;
            temp *= nums[i];
        }
        return result;
    }
}

