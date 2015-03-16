using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array and a value, remove all instances of that value in place and return the new length.

// The order of elements can be changed. It doesn't matter what you leave beyond the new length.

namespace LeetSharp
{
    [TestClass]
    public class Q027_RemoveElement
    {
        int[] RemoveElement(int[] a, int toRemove)
        {
            if (a.Length == 0)
                return a;
            int pointer = 0;
            int i = 0;
            while (i < a.Length)
            {
                if (a[i] != toRemove)
                {
                    a[pointer] = a[i];
                    pointer++;
                }
                i++;
            }
            return a.Take(pointer).ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(RemoveElement(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q027_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q027_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
