using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implement atoi to convert a string to an integer.

namespace LeetSharp
{
    [TestClass]
    public class Q008_StringtoInteger
    {
        public int Atoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;
            str = str.Trim();
            long result = 0;
            bool isNegative = false;
            if (str[0] == '-' || str[0] == '+')
            {
                isNegative = str[0] == '-';
                str = str.Substring(1);
            }
            foreach (var c in str)
            {
                if (c < '0' || c > '9')
                {
                    break;
                }
                result = result * 10;
                result = result + c - '0';
                if (result > int.MaxValue)
                {
                    return isNegative ? int.MinValue : int.MaxValue;
                }
            }
            return (int)(isNegative ? (-1) * result : result);
        }

        public string SolveQuestion(string input)
        {
            return Atoi(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q008_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q008_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
