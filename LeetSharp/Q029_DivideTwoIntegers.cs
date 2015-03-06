using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Divide two integers without using multiplication, division and mod operator.

namespace LeetSharp
{
    [TestClass]
    public class Q029_DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {

            const long ZERO = 0;
            long result = 0;
            short shift = 0;
            bool neg = false;
            long div2 = dividend, divisor2 = divisor;
            if (dividend < ZERO)
            {
                neg = !neg;
                div2 = ZERO - div2;
            }
            if (divisor < ZERO)
            {
                neg = !neg;
                divisor2 = ZERO - divisor2;
            }
            while (divisor2 << shift < div2)
                shift++;
            while (shift >= 0)
            {
                if (divisor2 << shift <= div2)
                {
                    result |= 1 << shift;
                    div2 -= divisor2 << shift;
                }
                shift--;
            }
            result = neg ? 0 - result : result;
            return (int)result;
        }

        public string SolveQuestion(string input)
        {
            return Divide(input.GetToken(0).ToInt(), input.GetToken(1).ToInt()).ToString();
        }

        [TestMethod]
        public void Q029_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q029_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
