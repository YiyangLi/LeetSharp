using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a collection of intervals, merge all overlapping intervals.

// For example,
// Given [1,3],[2,6],[8,10],[15,18],
// return [1,6],[8,10],[15,18].

namespace LeetSharp
{
    [TestClass]
    public class Q056_MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            Stack<int[]> result = new Stack<int[]>();
            if (intervals.Length == 0)
                return result.ToArray();
            intervals = intervals.OrderBy(i => i[0]).ToArray();
            result.Push(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                var current = result.Pop();
                if (current[1] >= intervals[i][0])
                {
                    if (current[1] >= intervals[i][1])
                        result.Push(current);
                    else
                        result.Push(new[] { current[0], intervals[i][1] });
                }
                else
                {
                    result.Push(current);
                    result.Push(intervals[i]);
                }
            }
            Stack<int[]> result2 = new Stack<int[]>();
            while (result.Count > 0)
            {
                result2.Push(result.Pop());
            }
            return result2.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Merge(input.ToIntArrayArray()));
        }

        [TestMethod]
        public void Q056_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q056_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
