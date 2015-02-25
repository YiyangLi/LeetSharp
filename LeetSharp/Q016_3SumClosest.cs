using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. 
// Return the sum of the three integers. You may assume that each input would have exactly one solution.

//    For example, given array S = {-1 2 1 -4}, and target = 1.

//    The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

namespace LeetSharp
{
    [TestClass]
    public class Q016_3SumClosest
    {
        public int ThreeSumClosest(int[] num, int target)
        {
            if (num.Length < 3)
                return target;
            int distance = Int32.MaxValue;
            int result = 0;
            QSort(ref num, 0, num.Length - 1);
            for (int i = 0; i < num.Length - 2; i++)
            {
                int left = i + 1;
                int right = num.Length - 1;
                while (left < right)
                {
                    int sum = num[i] + num[left] + num[right];
                    int cDistance = Math.Abs(sum - target);
                    if (cDistance < distance)
                    {
                        distance = cDistance;
                        result = sum;
                    }
                    if (sum > target)
                        right--;
                    if (sum < target)
                        left++;
                    if (sum == target)
                    {
                        i = num.Length;
                        break;
                    }
                }
            }
            return result;
        }
        public void QSort(ref int[] num, int left, int right)
        {
            if (left >= right)
                return;
            int pivot = num[left];
            int i = left + 1;
            int j = i;
            while (j <= right)
            {
                if (num[j] < pivot)
                {
                    Swap(ref num, i, j);
                    i++;
                }
                j++;
            }
            i = i - 1;
            Swap(ref num, i, left);
            QSort(ref num, left, i - 1);
            QSort(ref num, i + 1, right);
        }

        public void Swap(ref int[] number, int x, int y)
        {
            int temp = number[x];
            number[x] = number[y];
            number[y] = temp;
        }

        public string SolveQuestion(string input)
        {
            return ThreeSumClosest(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()).ToString();
        }

        [TestMethod]
        public void Q016_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q016_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
