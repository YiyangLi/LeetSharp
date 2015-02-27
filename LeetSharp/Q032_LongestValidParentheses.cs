using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) 
// parentheses substring.

// For "(()", the longest valid parentheses substring is "()", which has length = 2.

// Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

namespace LeetSharp
{
    [TestClass]
    public class Q032_LongestValidParentheses
    {
        public int LongestValidParentheses(string s)
        {
            int right = -1;
            int result = 0;
            Stack<int> left = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    left.Push(i);
                else
                {
                    if (left.Count == 0)
                        right = i;
                    else
                    {
                        left.Pop();
                        if (left.Count() == 0)
                            result = Math.Max(result, i - right);
                        else
                            result = Math.Max(result, i - left.Peek());
                    }
                }   
            }
            return result;
        }

        public string SolveQuestion(string input)
        {
            return LongestValidParentheses(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q032_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q032_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
