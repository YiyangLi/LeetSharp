using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? 
// Find all unique triplets in the array which gives the sum of zero.

// Note:
// Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ? b ? c)
// The solution set must not contain duplicate triplets.
//    For example, given array S = {-1 0 1 2 -1 -4},

//    A solution set is:
//    (-1, 0, 1)
//    (-1, -1, 2)

namespace LeetSharp
{
    [TestClass]
    public class Q015_3Sum
    {
        public int[][] ThreeSum(int[] num)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            var result = ThreeSum(input.ToIntArray());
            return TestHelper.Serialize(result);
        }

        [TestMethod]
        public void Q015_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q015_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
