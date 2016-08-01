using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class SpiralMatrix
    {
        public static IList<int> ZigZag(int[,] matrix)
        {
            var list = new List<int>();

            int i = 0;
            int j = 0;

            while (i < matrix.GetLength(0) && j < matrix.GetLength(1))
            {
                list.Add(matrix[i,j]);
                if (i%2 == 0)
                {
                    j++;
                    if (j == matrix.GetLength(1))
                    {
                        i++;
                        j--;
                    }
                }
                else
                {
                    j--;
                    if (j < 0)
                    {
                        i++;
                        j++;
                    }
                }
                if (i >= matrix.GetLength(0))
                {
                    break;
                }
            }

            return list;
        }

        public static IList<int> SpiralOrder(int[,] matrix)
        {
            var res = new List<int>();

            var i = 0;
            var j = -1;

            var directions = new int[][]
            {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {0, -1},
                new int[] {-1, 0},
            };

            var dirIdx = 0;
            var numOfRows = matrix.GetLength(0);
            var numOfColumns = matrix.GetLength(1);


            var maxSteps = new int[]
            {
                numOfColumns,
                numOfRows- 1
            };

            while (maxSteps[dirIdx%2] > 0)
            {
                for (var k = 0; k < maxSteps[dirIdx%2]; k++)
                {
                    i += directions[dirIdx%4][0];
                    j += directions[dirIdx%4][1];

                    res.Add(matrix[i,j]);
                }

                maxSteps[dirIdx%2]--;
                dirIdx++;
            }
            return res;
        }

        public static int[,] GenerateSpiralMatrix(int n)
        {
            var matrix = new int[n, n];

            var directions = new int[][]
            {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {0, -1},
                new int[] {-1, 0},
            };

            int i = 0;
            int j = -1;

            var number = 1;

            var maxSteps = new int[]
            {
                n, n -1
            };

            var dirIdx = 0;

            while (maxSteps[dirIdx % 2] > 0)
            {
                for (var k = 0; k < maxSteps[dirIdx%2]; k++)
                {
                    i += directions[dirIdx%4][0];
                    j += directions[dirIdx%4][1];

                    matrix[i, j] = number;
                    number++;
                }

                maxSteps[dirIdx%2]--;
                dirIdx++;
            }

            return matrix;
        }

        public static IList<int> SpiralOrderWrong(int[,] matrix)
        {
            var list = new List<int>();

            var i = 0;
            var j = 0;
            var imax = matrix.GetLength(0) - 1;
            var jmax = matrix.GetLength(1) - 1;
            var imin = 0;
            var jmin = 0;

            var directions = new int[][]
            {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {0, -1},
                new int[] {-1, 0},
            };

            var directionChanges = 0;
            var count = 0;
            while (count < matrix.GetLength(0) * matrix.GetLength(1))
            {
                var direction = directions[directionChanges%directions.Length];
                list.Add(matrix[i,j]);

                i += direction[0];
                j += direction[1];

                if (direction[0] != 0)
                {
                    i -= direction[0];
                    if ((i > imax || i < imin))
                    {
                        if (direction[0] > 0)
                        {
                            imax -= direction[0];
                            if (imax < 0) imax = 0;
                        }
                        else if (direction[0] < 0)
                        {
                            imin -= direction[0];
                            if (imin > matrix.GetLength(0))
                            {
                                imin = matrix.GetLength(0);
                            }
                        }
                        directionChanges++;
                        direction = directions[directionChanges%directions.Length];
                        i += direction[0];
                    }
                }
                else
                {
                    if (j > jmax || j < jmin)
                    {
                        j -= direction[1];
                        if (direction[1] > 0)
                        {
                            jmax -= direction[1];
                            if (jmax < 0) jmax = 0;
                        } else if (direction[1] < 0)
                        {
                            jmin -= direction[1];
                            if (jmin > matrix.GetLength(1)) jmin = matrix.GetLength(1);
                        }
                    }
                    directionChanges++;
                    direction = directions[directionChanges%directions.Length];
                    j += direction[1];
                }
                count++;
            }

            return list;

        }

    }
}
