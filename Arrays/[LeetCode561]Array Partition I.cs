public class Solution {
    public int ArrayPairSum(int[] nums) {
        Array.Sort(nums);
        int currentSum = 0;
        for(int i=0;i<nums.Length-1;i++)
        {
            currentSum += Math.Min(nums[i],nums[i+1]);
            i++;
        }
        
        return currentSum;
    }
}