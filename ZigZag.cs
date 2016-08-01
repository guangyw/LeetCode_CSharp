using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class ZigZag
    {
        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            var lists = new List<char>[numRows];
            for (var i = 0; i < lists.Length; i++)
            {
                lists[i] = new List<char>();
            }

            var direction = 1;
            var idx = 0;

            foreach (var c in s)
            {
                lists[idx].Add(c);
                idx += direction;
                if (idx >= numRows || idx < 0)
                {
                    idx -= direction;
                    direction *= -1;
                    idx += direction;
                }
            }

            var stringBuilder = new StringBuilder();
            foreach (var list in lists)
            {
                stringBuilder.Append(string.Join("", list.ToArray()));
            }

            return stringBuilder.ToString();
        }
    }
}
