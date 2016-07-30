using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class FindMinimumInRotatedSortedArray
    {
        public static int FindMin(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int left = 0;
            int right = nums.Length - 1;

            var rotatingPoint = FindRotatingPoint(nums, left, right);

            if (rotatingPoint == -1) return nums[0];

            return nums[rotatingPoint + 1];

        }

        public static int FindRotatingPoint(int[] nums, int left, int right)
        {
            if (left > right || left >= nums.Length -1 || right < 0)
            {
                return -1;
            }
            var mid = left + (right - left) / 2;

            if (nums[mid] < nums[mid + 1])
            {
                var findInLeftHalf = FindRotatingPoint(nums, left, mid - 1);

                return findInLeftHalf != -1 ? findInLeftHalf : FindRotatingPoint(nums, mid + 1, right);
            }
            else
            {
                return mid;
            }
        }

        public static int FindMinIndex(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;
            while (left < right)
            {
                var mid = left + (right - left)/2;
                if (nums[mid] >= nums[0])
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

        public static int FindMinCompareEnd(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;
            while (left < right)
            {
                var mid = left + (right - left)/2;
                if (nums[mid] == nums[right])
                {
                    for (var i = mid; i < right; i++)
                    {
                        if (nums[i] != nums[right])
                        {
                            return Math.Min(nums[i], nums[right]);
                        }
                    }


                    var j = mid;
                    while (j > left + 1 && nums[j] == nums[right] && nums[j - 1] != nums[left])
                    {
                        j--;
                    }

                    right = j;
                }
                else if (nums[mid] > nums[right])
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
