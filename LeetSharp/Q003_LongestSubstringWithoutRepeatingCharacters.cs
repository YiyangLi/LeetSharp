using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, find the length of the longest substring without repeating characters. 
// For example, the longest substring without repeating letters for "abcabcbb" is "abc", which the length is 3. 
// For "bbbbb" the longest substring is "b", with the length of 1.

namespace LeetSharp
{
    [TestClass]
    public class Q003_LongestSubstringWithoutRepeatingCharacters
    {
        int LengthOfLongestSubstring(string s)
        {
            //Greedy Algorithm
            var lastIndex = Enumerable.Range(0, 52).Select((_) => -1).ToArray();
            int maxLen = 0;
            int start = 0;
            int len = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int letterIndex = s[i] >= 'a' && s[i] <= 'z' ? s[i] - 'a' + 26 : s[i] - 'A';
                if (lastIndex[letterIndex] >= start)
                {
                    len = i - start;
                    if (len > maxLen)
                        maxLen = len;
                    start = lastIndex[letterIndex] + 1;
                }
                lastIndex[letterIndex] = i;
            }
            len = s.Length - start;
            if (len > maxLen)
                maxLen = len;
            return maxLen;
        }

        public string SolveQuestion(string input)
        {
            return LengthOfLongestSubstring(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q003_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q003_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
