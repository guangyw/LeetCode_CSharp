using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class SearchInRotatedSortedArray
    {
        public static int Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var mid = left + (right - left)/2;


                if (target == nums[mid]) return mid;
                if (nums[mid] > nums[right])
                {
                    if (target > nums[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        if (target > nums[left])
                        {
                            right = mid -1;
                        }
                        else if (target < nums[left])
                        {
                            left = mid + 1;
                        }
                    }
                }
                else if (nums[mid] < nums[right])
                {
                    if (target == nums[left]) return left;
                    if (target < nums[left])
                    {
                        if (target > nums[mid])
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    else
                    {
                        if (nums[mid] >= nums[left])
                        {
                            if (target > nums[mid])
                            {
                                left = mid + 1;
                            } else
                            {
                                right = mid - 1;
                            }
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                }
                else
                {
                    return mid;
                }
            }

            return nums[left] == target ? left : -1;
        }

    }
}
