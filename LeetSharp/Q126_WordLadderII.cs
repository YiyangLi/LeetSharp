using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two words (start and end), and a dictionary, find all shortest transformation 
// sequence(s) from start to end, such that:

// Only one letter can be changed at a time
// Each intermediate word must exist in the dictionary
// For example,

// Given:
// start = "hit"
// end = "cog"
// dict = ["hot","dot","dog","lot","log"]

// Return

//   [
//     ["hit","hot","dot","dog","cog"],
//     ["hit","hot","lot","log","cog"]
//   ]
// Note:

// All words have the same length.
// All words contain only lowercase alphabetic characters.

namespace LeetSharp
{
    [TestClass]
    public class Q126_WordLadderII
    {
        public string[][] FindLadders(string start, string end, string[] dict)
        {
            HashSet<string> visited = new HashSet<string>();
            visited.Add(start);
            Dictionary<string, List<string>> graph;
            Dictionary<string, List<string>> path = new Dictionary<string,List<string>>();
            foreach (var s in dict)
            {
                if (!path.ContainsKey(s))
                    path.Add(s, new List<string>());
            }
            if (!ConvertToGraph(path.Keys.ToArray(), out graph) || graph[start].Count() == 0 || graph[end].Count() == 0)
                return new string[0][];
            visited.Add(start);
            var hset = new HashSet<string>();
            hset.Add(start);
            //unvisited.Remove(start);
            while (hset.Count() > 0)
            {
                var nextProceeding = new List<string>();
                var newHSet = new HashSet<string>();
                foreach (var vertex in hset)
                {
                    visited.Add(vertex);
                    foreach (var adj in graph[vertex])
                    {
                        if (!visited.Contains(adj) && !hset.Contains(adj))
                        {
                            path[adj].Add(vertex);
                            newHSet.Add(adj);
                            //route[adj] = vertex;
                        }
                    }
                }
                hset = null;
                hset = newHSet;
            }
            var node = end;
            Queue<List<string>> qPath = new Queue<List<string>>();
            qPath.Enqueue(new List<string>() { node });
            while (qPath.Peek().First() != start) // make sure it ends at the shorest path (zero-layer)
            {
                var currentPath = qPath.Dequeue();
                node = currentPath.First();
                foreach (var next in path[node])
                {
                    var newPath = new [] { next }.Concat(currentPath).ToList();
                    qPath.Enqueue(newPath);
                }
            }
            return qPath.Select(i => i.ToArray()).ToArray();
        }

        private int CompareStringArray(string[] arr1, string[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                int res = arr1[i].CompareTo(arr2[i]);
                if (res != 0)
                {
                    return res;
                }
            }
            return 0;
        }

        private bool AreStringArrayArrayEqual(string expected, string actual)
        {
            var arrExp = expected.ToStringArrayArray().ToList();
            var arrActual = actual.ToStringArrayArray().ToList();
            arrExp.Sort(CompareStringArray);
            arrActual.Sort(CompareStringArray);
            return TestHelper.Serialize(arrExp.ToArray()) ==
                TestHelper.Serialize(arrActual.ToArray());
        }

        /// <summary>
        /// the graph is actually a Dict<string, List<string>> where the key is the vertex, and value (string list) is the adjacent vertices
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="graph"></param>
        /// <returns></returns>
        private bool ConvertToGraph(string[] dict, out Dictionary<string, List<string>> graph)
        {
            graph = new Dictionary<string, List<string>>();
            try
            {
                foreach (var s in dict)
                {
                    graph.Add(s, new List<string>());
                }
                for (int i = 0; i < dict.Length; i++)
                    for (int j = i + 1; j < dict.Length; j++)
                    {
                        if (dict[i].Length == dict[j].Length)
                        {
                            var diffCount = 0;
                            for (int k = 0; k < dict[i].Length; k++)
                                if (dict[i][k] != dict[j][k])
                                    diffCount++;
                            if (diffCount == 1)
                            {
                                graph[dict[i]].Add(dict[j]);
                                graph[dict[j]].Add(dict[i]);
                            }
                        }
                    }
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Undexpected Error caught: {0}!", ex.Message);
                return false;
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(FindLadders(input.GetToken(0).Deserialize(),
                input.GetToken(1).Deserialize(), input.GetToken(2).ToStringArray()));
        }

        [TestMethod]
        public void Q126_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringArrayArrayEqual);
        }
        [TestMethod]
        public void Q126_Large()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringArrayArrayEqual);
        }
    }
}
