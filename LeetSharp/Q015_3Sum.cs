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
            if (num.Length < 3)
                return new int[0][];
            List<int[]> result = new List<int[]>();
            QSort(ref num, 0, num.Length - 1);
            for (int i = 0; i < num.Length - 2; i++)
            {
                int left = i + 1;
                int right = num.Length - 1;
                while (left < right)
                {
                    var arr = new int[] { num[i], num[left], num[right] }; //ascending
                    var sum = arr.Sum();
                    if (sum == 0)
                    {
                        if (!result.Any(elem => elem[0] == arr[0] && elem[1] == arr[1] && elem[2] == arr[2])) 
                            result.Add(arr);
                        while (left <= right && num[right] == arr[2])
                            right--;
                        while (left <= right && num[left] == arr[1])
                            left++;
                    }
                    if (sum > 0)
                        right--;
                    if (sum < 0)
                        left++;
                }
            }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            var result = ThreeSum(input.ToIntArray());
            return TestHelper.Serialize(result);
        }

        /// <summary>
        /// left and right inclusive
        /// </summary>
        /// <param name="num"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void QSort(ref int[] num, int left, int right)
        {
            if (left >= right)
                return;
            var pivot = num[left];
            var i = left + 1;
            var j = i;
            while (j <= right)
            {
                if (pivot > num[j])
                {
                    Swap(ref num, i, j);
                    i++;
                }
                j++;
            }
            i = i - 1;
            Swap(ref num, left, i);
            QSort(ref num, left, i - 1);
            QSort(ref num, i + 1, right);
        }
        public void Swap(ref int[] num, int x, int y)
        {
            int temp = num[x];
            num[x] = num[y];
            num[y] = temp;
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
