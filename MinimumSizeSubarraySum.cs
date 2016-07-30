using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class MinimumSizeSubarraySum
    {
        public static int MinSubArrayLen(int s, int[] nums)
        {
            int [] sumArray = new int[nums.Length];
            sumArray[0] = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                sumArray[i] = sumArray[i - 1] + nums[i];
            }

            var minLen = int.MaxValue;

            for (var j = 0; j < sumArray.Length; j++)
            {
                var endOfSubArray = FindCeiling(sumArray, j, sumArray.Length -1, s + sumArray[j]);
                if (endOfSubArray == -1) break;

                minLen = Math.Min(endOfSubArray - j, minLen);
            }

            return minLen == int.MaxValue ? 0 : minLen;
        }

        public static int FindCeiling(int[] candidates, int left, int right, int target)
        {
            if (candidates[right] < target) return -1;

            while (left < right)
            {
                var mid = left + (right - left)/2;

                if (candidates[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

    }
}
