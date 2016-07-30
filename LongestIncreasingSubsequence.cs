using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class LongestIncreasingSubsequence
    {
        public static int FindLongestIncreasingSubsequence(int[] nums)
        {
            if (nums.Length <= 1)
                return nums.Length;
            var maxSubSequenceList = new int[nums.Length];
            maxSubSequenceList[0] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                var max = 0;
                for (int j = 0; j < i; ++j)
                {

                    if (nums[i] > nums[j] && maxSubSequenceList[j] > max)
                    {
                        max = maxSubSequenceList[j];
                    }
                }
                maxSubSequenceList[i] = max + 1;
            }
            return maxSubSequenceList.Max();
        }

        //Binary search 
        public static int FindLongestIncreasingSubsequenceBinarySearch(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;

            var size = 1;
            var tails = new List<int> {nums[0]};
            for (var i = 1; i < nums.Length; i++)
            {
                var value = nums[i];
                if (value > tails.Last())
                {
                    tails.Add(value);
                    size++;
                }
                else
                {
                    var tailToReplace = FindCeilingIndex(tails, value);
                    tails[tailToReplace] = value;
                }
            }


            return size;
        }

        public static int FindCeilingIndex(IList<int> nums, int target)
        {
            var left = 0;
            var right = nums.Count - 1;

            while (left < right)
            {
                var mid = left + (right - left)/2;
                if (nums[mid] < target)
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

        public static int FindFloorIndex(IList<int> nums, int target)
        {
            var left = 0;
            var right = nums.Count - 1;
            while (left < right - 1)
            {
                var mid = left + (right - left)/2;
                if (nums[mid] <= target)
                {
                    left = mid;
                }
                else
                {
                    right = mid -1;
                }
            }

            return left;
        }

        public static int FindCeilingIndex2(IList<int> nums, int target)
        {
            if (nums.Count == 0) return 0;
            if (target > nums.Last())
            {
                return nums.Count;
            }


            var left = 0;
            var right = nums.Count - 1;
            
            while (left < right)
            {
                var mid = left + (right - left)/2;
                if (nums[mid] < target)
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
