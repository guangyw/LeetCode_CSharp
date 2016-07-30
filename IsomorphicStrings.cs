using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class IsomorphicStrings
    {
        public static bool IsIsomorphic(string s, string t)
        {
            var smap = new Dictionary<char, int>();
            var tmap = new Dictionary<char, int>();
            if (s.Length != t.Length) return false;
            for (var i = 0; i < s.Length; i++)
            {
                if (smap.ContainsKey(s[i]) && tmap.ContainsKey(t[i]))
                {
                    if (smap[s[i]] != tmap[t[i]]) return false;
                }
                else if (!smap.ContainsKey(s[i]) && !tmap.ContainsKey(t[i]))
                {
                    smap[s[i]] = i;
                    tmap[t[i]] = i;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
