using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string S, find the longest palindromic substring in S. 
// You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.

namespace LeetSharp
{
    [TestClass]
    public class Q005_LongestPalindromicSubstring
    {
        string LocalLongest(string input, int left, int right)
        {
            while (left >= 0 && right < input.Length && input[left] == input[right])
            {
                left--;
                right++;
            }
            return input.Substring(left + 1, right - left - 1);
        }
        string LongestPalindrome(string input)
        {
            if (input.Length == 1)
                return input;
            var result = string.Empty;
            for (int i = 0; i < input.Length - 1; i++)
            {
                string p1 = LocalLongest(input, i, i);
                if (p1.Length > result.Length)
                    result = p1;
                p1 = LocalLongest(input, i, i + 1);
                if (p1.Length > result.Length)
                    result = p1;
            }
            return result;
        }

        IEnumerable<char> hashSign()
        {
            while(true)
                yield return '#';
        }

        public string SolveQuestion(string input)
        {
            return "\"" + LongestPalindrome(input.Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q005_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q005_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
