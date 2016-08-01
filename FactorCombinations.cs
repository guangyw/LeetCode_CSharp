using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class FactorCombinations
    {
        public IList<IList<int>> GetFacotrCombinations(int n)
        {
            var list = new List<int>();
            var lists = new List<IList<int>>();
            GetFactorCombinationsHelper(n, list, lists);
            return lists;
        }



        public void GetFactorCombinationsHelper(int target, IList<int> list, IList<IList<int>> lists)
        {
            if (target == 1)
            {
                lists.Add(new List<int>(list));
                return;
            }

            for (var i = 2; i < target/2; i++)
            {
                if (target%i != 0)
                {
                    continue;
                }

                list.Add(i);
                GetFactorCombinationsHelper(target / i, list, lists);
                list.RemoveAt(list.Count -1);
            }
        }
    }
}
