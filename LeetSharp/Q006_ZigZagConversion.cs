﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:
// (you may want to display this pattern in a fixed font for better legibility)

// P   A   H   N
// A P L S I I G
// Y   I   R
// And then read line by line: "PAHNAPLSIIGYIR"
// Write the code that will take a string and make this conversion given a number of rows:

// string convert(string text, int nRows);
// convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".

namespace LeetSharp
{
    [TestClass]
    public class Q006_ZigZagConversion
    {
        public string Convert(string s, int nRows)
        {
            if (nRows == 1)
                return s;
            var goldenStep = 2 * nRows - 2;
            var result = new char[s.Length];
            var k = 0;
            for (int row = 0; row < nRows; row++)
            {
                for (int i = row; i < s.Length; i = i + goldenStep)
                {
                    result[k++] = s[i];
                    if ((row != 0) && row != (nRows - 1) && nRows > 2 && (i + goldenStep - 2 * row) < s.Length)
                        result[k++] = s[i + goldenStep - 2 * row];
                }
            }
            return new string(result);
        }

        public string SolveQuestion(string input)
        {
            return "\"" + Convert(input.GetToken(0).Deserialize(), input.GetToken(1).ToInt()) + "\"";
        }

        [TestMethod]
        public void Q006_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q006_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
