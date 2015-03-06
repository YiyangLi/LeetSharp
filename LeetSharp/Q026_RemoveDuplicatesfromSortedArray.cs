using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

// Do not allocate extra space for another array, you must do this in place with constant memory.

// For example,
// Given input array A = [1,1,2],

// Your function should return [1,2].

namespace LeetSharp
{
    [TestClass]
    public class Q026_RemoveDuplicatesfromSortedArray
    {
        public int[] RemoveDuplicates(int[] a)
        {
            if (a.Length == 0)
                return a;
            int pointer = 0;
            int i = 1;
            while (i < a.Length)
            {
                if (a[pointer] != a[i])
                {
                    pointer++;
                    a[pointer] = a[i];
                }
                i++;
            }
            return a.Take(pointer + 1).ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(RemoveDuplicates(input.ToIntArray()));
        }

        [TestMethod]
        public void Q026_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q026_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
