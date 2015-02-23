using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Determine whether an integer is a palindrome. Do this without extra space.

namespace LeetSharp
{
    [TestClass]
    public class Q009_PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            int div = 1;
            var isPalindrome = true;
            while (x / div >= 10)
                div *= 10;
            while (isPalindrome && x >= 10)
            {
                var first = (int)(x / div);
                var last = x % 10;
                x = (x % div) / 10;
                if (first != last)
                    isPalindrome = false;
                div = div / 100;
            }
            return isPalindrome;
        }

        public string SolveQuestion(string input)
        {
            return IsPalindrome(input.ToInt()).ToString().ToLower();
        }

        [TestMethod]
        public void Q009_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q009_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
