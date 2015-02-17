﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Reverse digits of an integer.

// Example1: x = 123, return 321
// Example2: x = -123, return -321

namespace LeetSharp
{
    [TestClass]
    public class Q007_ReverseInteger
    {
        public int ReverseInterger(int x)
        {
            bool isNegative = x < 0;
            x = Math.Abs(x);
            int result = x % 10;
            while (x / 10 > 0)
            {
                result = result * 10;
                x = x / 10;
                result = result + x % 10;
            }
            return isNegative ? (-1) * result : result;
        }

        public string SolveQuestion(string input)
        {
            return ReverseInterger(input.ToInt()).ToString();
        }

        [TestMethod]
        public void Q007_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q007_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
