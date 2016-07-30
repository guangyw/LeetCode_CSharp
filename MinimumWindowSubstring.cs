using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            var charCountDict = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!charCountDict.ContainsKey(c))
                {
                    charCountDict[c] = 0;
                }

                charCountDict[c]++;
            }

            Queue<char> charQueue = new Queue<char>();
            var minString = s + '.';

            for(int i = 0, j = 0; i < s.Length && j < s.Length; j++)
            {
                if (!charCountDict.ContainsKey(s[j]))
                {
                    if (i == j)
                    {
                        i++;
                    }
                    else
                    {
                        charQueue.Enqueue(s[j]);
                    }
                    continue;
                }

                charQueue.Enqueue(s[j]);
                if (--charCountDict[s[j]] < 0)
                {
                    if (charQueue.Count == 1 && s[j] == charQueue.Peek())
                    {
                        i++;
                        charQueue.Enqueue(charQueue.Dequeue());
                        charCountDict[s[j]]++;
                    }
                }

                if (charCountDict.Values.All(value => value <= 0))
                {
                    var curString = string.Join("",charQueue.ToArray());
                    if (curString.Length < minString.Length)
                    {
                        minString = curString;
                    }

                    i++;
                    charCountDict[charQueue.Dequeue()]++;
                    while (charQueue.Count > 0)
                    {
                        var c = charQueue.Dequeue();
                        if (charCountDict.ContainsKey(c))
                        {
                            if (charCountDict[c] < 0)
                            {
                                charCountDict[c]++;
                            } else
                            {
                                break;
                            }
                        }
                        i++;
                    }
                }
            }

            return minString == s + '.' ? "" : minString;
        }
    }
}
