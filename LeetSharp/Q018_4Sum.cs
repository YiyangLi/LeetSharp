using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? 
// Find all unique quadruplets in the array which gives the sum of target.

// Note:
// Elements in a quadruplet (a,b,c,d) must be in non-descending order. (ie, a ? b ? c ? d)
// The solution set must not contain duplicate quadruplets.
//    For example, given array S = {1 0 -1 0 -2 2}, and target = 0.

//    A solution set is:
//    (-1,  0, 0, 1)
//    (-2, -1, 1, 2)
//    (-2,  0, 0, 2)

namespace LeetSharp
{
    [TestClass]
    public class Q018_4Sum
    {
        public int[][] FourSum(int[] num, int target)
        {
            List<int[]> result = new List<int[]>();
            HashSet<string> hset = new HashSet<string>();
            var cache = new Dictionary<int, List<int[]>>();
            if (num.Length <= 3)
                return result.ToArray();
            num = num.OrderBy(i => i).ToArray();
            for (int i = 0; i < num.Length - 1; i++)
                for (int j = i + 1; j < num.Length; j++)
                {
                    int sum = num[i] + num[j];
                    if (!cache.ContainsKey(sum))
                    {
                        cache.Add(sum, new List<int[]>());
                    }
                    cache[sum].Add(new [] { i, j });
                }
            for (int i = 0; i < num.Length - 1; i++)
                for (int j = i + 1; j < num.Length; j++)
                {
                    var key = target - num[i] - num[j];
                    if (!cache.ContainsKey(key))
                        continue;
                    for (int k = 0; k < cache[key].Count; k++)
                    {
                        var vec = cache[key][k];
                        if (j >= vec[0])
                            continue; //make sure i, j < vec[0], vec[1]
                        var idx = string.Format("{0},{1},{2},{3}", num[i], num[j], num[vec[0]], num[vec[1]]);
                        if (!hset.Contains(idx))
                            hset.Add(idx);
                        else
                            continue; //remove duplicated element set. 
                        result.Add(new int[] { num[i], num[j], num[vec[0]], num[vec[1]] });
                    }
                }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(FourSum(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q018_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q018_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
