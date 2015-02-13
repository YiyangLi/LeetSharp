using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// There are two sorted arrays A and B of size m and n respectively. Find the median of the two sorted arrays. 
// The overall run time complexity should be O(log (m+n)).

namespace LeetSharp
{
    [TestClass]
    public class Q004_MedianofTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] a, int[] b)
        {
            int totalLen = a.Length + b.Length;
            int midIndex1 = (totalLen - 1) / 2;
            int midIndex2 = totalLen / 2;
            if (a.Length == 0)
                return (double)(b[midIndex1] + b[midIndex2]) / 2.0;
            if (b.Length == 0)
                return (double)(a[midIndex1] + a[midIndex2]) / 2.0;
            if (midIndex1 == midIndex2)
                return FindKthSmallest(a, b, midIndex1);
            else
                return (double)(FindKthSmallest(a, b, midIndex1) + FindKthSmallest(a, b, midIndex2)) / 2.0;
        }

        private T FindKthSmallest<T>(T[] a, T[] b, int k)
            where T : IComparable, IComparable<int>
        {
            int left = 0;
            int right = a.Length - 1;
            while (left <= right)
            {
                int indexA = (left + right) / 2;
                int indexB = k - indexA - 1;
                if (indexB >= b.Length)
                {
                    //increase indexA (move to right part) to get some B
                    left = indexA + 1;
                    continue;
                }
                if (indexB < -1)
                {
                    //decrease indexA (move to left part) to get some B
                    right = indexA - 1;
                    continue;
                }
                if (indexB == -1)
                {
                    //indexA is kth between left and right, but we need to make sure, pivot is less than B[0], unless we need to decrease the pivot. 
                    if (a[indexA].CompareTo(b[0]) <= 0)
                        return a[indexA];
                    else
                        right = indexA - 1;
                    continue;
                }
                if (a[indexA].CompareTo(b[indexB]) >=0 )
                {
                    //if the pivot of A is larger than the left part of B, we decrease the pivot and include more B next time. 
                    if (indexB == b.Length - 1 || a[indexA].CompareTo(b[indexB + 1]) <= 0)
                        return a[indexA];
                    else
                        right = indexA - 1;
                }
                else
                {
                    //if the pivot of A is less than B, we increase pivot. 
                    left = indexA + 1;
                }
            }
            return FindKthSmallest(b, a, k);
        }

        public string SolveQuestion(string input)
        {
            return FindMedianSortedArrays(input.GetToken(0).ToIntArray(), input.GetToken(1).ToIntArray()).ToString("F5");
        }

        [TestMethod]
        public void Q004_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q004_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
