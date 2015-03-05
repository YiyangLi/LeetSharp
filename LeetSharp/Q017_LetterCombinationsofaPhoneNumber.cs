using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a digit string, return all possible letter combinations that the number could represent.

// A mapping of digit to letters (just like on the telephone buttons) is given below.

// Input:Digit string "23"
// Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

namespace LeetSharp
{
    [TestClass]
    public class Q017_LetterCombinationsofaPhoneNumber
    {
        
        public string[] LetterCombinations(string digits)
        {
            string[] mapping = new string[] { string.Empty, string.Empty, "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            var result = new string[] {string.Empty};
            foreach (char c in digits)
            {
                result = (from ch in mapping[(int)(c - '0')]
                          from str in result
                          select string.Format("{0}{1}", str, ch)).ToArray();
            }
            return result.OrderBy(s => s).ToArray(); //in order to match the testing data set, totally unnecessary. 
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(LetterCombinations(input.Deserialize()));
        }

        [TestMethod]
        public void Q017_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q017_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
