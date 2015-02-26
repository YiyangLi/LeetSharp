using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

// For example, given n = 3, a solution set is:

// "((()))", "(()())", "(())()", "()(())", "()()()"

namespace LeetSharp
{
    [TestClass]
    public class Q022_GenerateParentheses
    {
        private List<string> result;
        public string[] GenerateParenthesis(int n)
        {
            result = new List<string>();
            Stack<string> str = new Stack<string>();
            Stack<int> left = new Stack<int>();
            Stack<int> right = new Stack<int>();
            str.Push(string.Empty);
            left.Push(0);
            right.Push(0);
            while (str.Count() != 0 && left.Count() != 0 && right.Count() != 0)
            {
                var s = str.Pop();
                var l = left.Pop();
                var r = right.Pop();
                if (l == n)
                {
                    result.Add(s + string.Concat(Enumerable.Repeat(')', n - r)));
                    continue;
                }
                str.Push(s + '(');
                left.Push(l + 1);
                right.Push(r);
                if (l > r)
                {
                    str.Push(s + ')');
                    left.Push(l);
                    right.Push(r + 1);
                }
            }
            return result.OrderBy(i => i).ToArray(); ;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(GenerateParenthesis(input.ToInt()));
        }

        [TestMethod]
        public void Q022_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q022_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
