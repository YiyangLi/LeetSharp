using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an integer, convert it to a roman numeral.

// Input is guaranteed to be within the range from 1 to 3999.

namespace LeetSharp
{
    [TestClass]
    public class Q012_IntegertoRoman
    {
        public string IntToRoman(int num)
        {
            List<string> result = new List<string>();
            int thousands = num / 1000;
            int hundreds = num % 1000 / 100;
            int tens = num % 100 / 10;
            int digits = num % 10;
            if (thousands > 0)
            { //either 1, 2, or 3, since the max is 3999. 
                result.Add(new string('M', thousands));
            }
            if (hundreds > 0)
            { //0 - 9
                result.Add(Roman(hundreds, 'C', 'D', 'M'));
            }
            if (tens > 0)
            { //0 - 9
                result.Add(Roman(tens, 'X', 'L', 'C'));
            }
            if (digits > 0)
            { //0 - 9
                result.Add(Roman(digits, 'I', 'V', 'X'));
            }
            return string.Concat(result);
        }

        public string Roman(int num, char pre, char mid, char next)
        {
            string result = string.Empty;
            switch (num)
            { 
                case 1:
                case 2:
                case 3:
                    result = new string(pre, num);
                    break;
                case 4:
                    result = new string(new[] { pre, mid });
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    result = string.Concat(mid, new string(pre, num - 5));
                    break;
                case 9:
                    result = new string(new[] { pre, next });
                    break;
                default:
                    //error
                    break;
            }
            return result;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + IntToRoman(input.ToInt()) + "\"";
        }

        [TestMethod]
        public void Q012_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q012_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
