using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Point
    {
        public int x;
        public int y;
        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(int a, int b)
        {
            x = a;
            y = b;
        }
    }

    public static class MaxPointsOnALine
    {
        public static int MaxPoints(Point[] points)
        {
            if (points.Length == 0) return 0;
            var slopeDictionary = new Dictionary<double, HashSet<Point>>();
            for (var i = 0; i < points.Length; i++)
            {
                for (var j = i + 1; j < points.Length; j++)
                {
                    //todo consider sitution divider is zero
                    var slope =(double) (points[j].y - points[i].y)/(points[j].x - points[i].x);
                    if (!slopeDictionary.ContainsKey(slope))
                    {
                        slopeDictionary.Add(slope, new HashSet<Point>());
                    }
                    slopeDictionary[slope].Add(points[i]);
                    slopeDictionary[slope].Add(points[j]);

                    //slopeDictionary[slope].Add($"{points[i].x} | {points[i].y}");
                    //slopeDictionary[slope].Add($"{points[j].x} | {points[j].y}");

                    //slopeDictionary[slope].Add(string.Format("{0}|{1}", points[i].x, points[i].y));
                    //slopeDictionary[slope].Add(string.Format("{0}|{1}", points[j].x, points[j].y));
                }
            }

            var maxPoints = 1;
            foreach (var entry in slopeDictionary)
            {
                var slope = entry.Key;
                var pointsSet = entry.Value;

                var yValueDict = new Dictionary<int, int>();
                foreach(var point in pointsSet)
                {
                    var yValue = point.y - slope*point.x;
                    //if (yValueDict.ContainsKey(yValue)) ;

                }
                maxPoints = Math.Max(maxPoints, pointsSet.Count);
            }

            return maxPoints;
        }
    }
}
