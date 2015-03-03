using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a roman numeral, convert it to an integer.

// Input is guaranteed to be within the range from 1 to 3999.

namespace LeetSharp
{
    [TestClass]
    public class Q013_RomantoInteger
    {
        int RomanToInt(string s)
        {
            int num = 0;
            int i = 0;
            while (i < s.Length)
            {
                var p = match4Or9(s, i);
                if (p > 0)
                {
                    num = num + p;
                    i = i + 1;
                }
                else
                    num = num + matchOthers(s, i);
                i++;
            }
            return num;
        }
        int match4Or9(string s, int i)
        {
            int num = 0;
            if (i == s.Length - 1)
                num = 0;
            else
            {
                if (s[i] == 'I')
                {
                    if (s[i + 1] == 'V')
                        num = 4;
                    else if (s[i + 1] == 'X')
                        num = 9;
                }
                if (s[i] == 'X')
                {
                    if (s[i + 1] == 'L')
                        num = 40;
                    else if (s[i + 1] == 'C')
                        num = 90;
                }
                if (s[i] == 'C')
                {
                    if (s[i + 1] == 'D')
                        num = 400;
                    else if (s[i + 1] == 'M')
                        num = 900;
                }
            }
            return num;
        }
        int matchOthers(string s, int i)
        {
            int num = 0;
            switch (s[i])
            {
                case 'I':
                    num = 1;
                    break;
                case 'V':
                    num = 5;
                    break;
                case 'X':
                    num = 10;
                    break;
                case 'L':
                    num = 50;
                    break;
                case 'C':
                    num = 100;
                    break;
                case 'D':
                    num = 500;
                    break;
                case 'M':
                    num = 1000;
                    break;
            }
            return num;
        }

        public string SolveQuestion(string input)
        {
            return RomanToInt(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q013_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q013_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
