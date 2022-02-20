using System;
namespace maximun_subarray
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] nums = new int[] {3, -2, 5, -1};
      var result = SubArrayDivideAndConquer(nums, 0, nums.Length - 1);
      System.Console.WriteLine("El valor maximo es -> " + result);
    }
    // time complexity -> O(n^3)
    static int SubArrayBruteForce(int[] nums, int length)
    {
      int ans = int.MinValue;
      for (int sub_array_size = 1; sub_array_size <= length; sub_array_size++)
      {
        for (int start_index = 0; start_index < length; start_index++)
        {
          if (start_index + sub_array_size > length) break;
          int sum = 0;
          for (int i = start_index; i < (start_index + sub_array_size); i++)
          {
            sum += nums[i];
          }
          ans = Math.Max(ans, sum);
        }
      }
      return ans;
    }
    // using previously calculated values - O(n^2)
    static int SubArrayBruteForceImproved(int[] nums, int length)
    {
      int ans = int.MinValue;
      for (int start_index = 0; start_index < length; start_index++)
      {
        int sum = 0;
        for (int sub_array_size = 1; sub_array_size <= length; sub_array_size++)
        {
          if (start_index + sub_array_size > length) break;
          sum += nums[start_index + sub_array_size - 1];
          ans = Math.Max(ans, sum);
        }
      }
      return ans;
    }
    // T(n) = C if n = 1
    // T(n) = 2T(n/2) + C'n if n > 1
    static int SubArrayDivideAndConquer(int[] nums, int left, int right)
    {
      if (left == right) return nums[left];
      int m = (left + right) / 2;

      int left_MSS = SubArrayDivideAndConquer(nums, left, m);
      int right_MSS = SubArrayDivideAndConquer(nums, m + 1, right);

      return Math.Max(
        Math.Max(left_MSS, right_MSS),
        MaxCrossingSum(nums, left, m, right)
      );
    }
    static int MaxCrossingSum(int[] nums, int l, int m, int r)
    {
      int leftSum = int.MinValue, rightSum = int.MinValue, sum = 0;
      //include elements on left of mid
      for (int i = m; i >= l; i--)
      {
        sum += nums[i];
        leftSum = Math.Max(leftSum, sum);
      }
      sum = 0;
      //include elements on right of mid
      for (int i = m + 1; i <= r; i++)
      {
        sum += nums[i];
        rightSum = Math.Max(rightSum, sum);
      }
      return Math.Max(leftSum + rightSum, Math.Max(leftSum, rightSum));
    }
  }
}
