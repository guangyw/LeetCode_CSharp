using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipzag = ZigZag.Convert("gtvsruapegkjfpxheeneviubicjexfofymxqizfohqymhxuobjuytqzctkgqpvvohugrvnfcfdopakdct", 27);
            var matrix2 = new int[,]
            {
                {2, 5},
                {8, 4},
                {0, -1}
            };

            var matrix = new int[,]
            {
                {2, 3}
            };

            var output = SpiralMatrix.SpiralOrder(matrix);

            var board = new int[,]
            {
                {1, 1},
                {1, 0}
            };
            GameOfLife.NextBoard(board);
            var minWindow = MinimumWindowSubstring.MinWindow("bba", "ab");
            var maxPoints = MaxPointsOnALine.MaxPoints(new Point[]
            {
                new Point(0, -12),
                new Point(5, 2),
                new Point(2, 5),
                new Point(0, -5),
                new Point(1, 5),
                new Point(2, -2),
                new Point(5, 4),
                new Point(5, 2),
            });

            var foundMinSubarrary = MinimumSizeSubarraySum.MinSubArrayLen(11, new int[] { 1, 2, 3, 4, 5 });

            var findTarget2 = SearchInRotatedSortedArray.Search(new int[] {4,5,6,7,8,1,2,3}, 8);
            var findTarget = SearchInRotatedSortedArray.Search(new int[] {4, 1, 2, 3}, 3);

            var ceiling = LongestIncreasingSubsequence.FindCeilingIndex(new List<int>() {1, 2, 4}, 2);
            var floor = LongestIncreasingSubsequence.FindFloorIndex(new List<int>() {1, 2, 4}, 3);


            var minIndex = FindMinimumInRotatedSortedArray.FindMinIndex(new int[] {1, 2});
            var minIndex4 = FindMinimumInRotatedSortedArray.FindMinCompareEnd(new int[] {1, 1, 3, 1});
            var minIndex2 = FindMinimumInRotatedSortedArray.FindMinCompareEnd(new int[] {3, 1, 1});
            var minIndex3 = FindMinimumInRotatedSortedArray.FindMinCompareEnd(new int[] {3, 3, 1, 3});

            var mid = FindMinimumInRotatedSortedArray.FindMin(new int[] {3, 1, 2});
        }
    }
}
