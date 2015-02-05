using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an array of integers, find two numbers such that they add up to a specific target number.

// The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

// You may assume that each input would have exactly one solution.

// Input: numbers={2, 7, 11, 15}, target=9
// Output: index1=1, index2=2

namespace LeetSharp
{
    [TestClass]
    public class Q001_TwoSum
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var hashing = new HashSet<int>();
            if (numbers.All(hashing.Add))
                //If we could make sure that the elements are distinct in the IEnumerable<T>, we should leverage hash table 
                return TwoSum2(numbers, target);
            else
            {
                for (int i = 0; i < numbers.Count() - 1; i++)
                    for (int j = i + 1; j < numbers.Count() - 1; j++)
                        if (numbers[i] + numbers[j] == target)
                            return new int[] { i + 1, j + 1 };
            }
            return null;
            
        }
        public int[] TwoSum2(int[] numbers, int target)
        {
            var hashing = numbers.Select((num, index) => new { Key = num, Value = index })
                                .ToDictionary(a => a.Key, a => a.Value);
            foreach (var number in numbers)
            {
                if (hashing.ContainsKey(target - numbers[hashing[number]]))
                    return new int[] { hashing[number] + 1, hashing[target - numbers[hashing[number]]] + 1 };
            }
            return null;
        }

        public static void QSort(int[] numbers, int left, int right)
        {
            if (left >= right)
                return;
            Swap(ref numbers, left, left + (right - left) / 2);
            int pivot = numbers[left];
            int i = left + 1;
            for (int j = i; j <= right; j++)
            {
                if (numbers[j] <= pivot)
                {
                    Swap(ref numbers, i, j);
                    i++;
                }
            }
            Swap(ref numbers, left, i - 1);
            QSort(numbers, left, i - 1);
            QSort(numbers, i, right);
        }

        public static void Swap(ref int[] numbers, int x, int y)
        {
            int temp = numbers[x];
            numbers[x] = numbers[y];
            numbers[y] = temp;
        }

        public string SolveQuestion(string input)
        {
            return String.Join(", ", TwoSum(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q001_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q001_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
