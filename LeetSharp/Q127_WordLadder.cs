using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two words (start and end), and a dictionary, 
// find the length of shortest transformation sequence from start to end, such that:

// Only one letter can be changed at a time
// Each intermediate word must exist in the dictionary
// For example,

// Given:
// start = "hit"
// end = "cog"
// dict = ["hot","dot","dog","lot","log"]

// As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
// return its length 5.

// Note:

// Return 0 if there is no such transformation sequence.
// All words have the same length.
// All words contain only lowercase alphabetic characters.

namespace LeetSharp
{
    [TestClass]
    public class Q127_WordLadder
    {
        public int LadderLength(string start, string end, string[] dict)
        {
            //dict = dict.GroupBy(i => i).Select(i => i.FirstOrDefault()).ToArray(); //remove duplicated words, appearred in large testing data. 
            HashSet<string> unvisited = new HashSet<string>(dict);
            //HashSet<string> visited = new HashSet<string>();
            Dictionary<string, List<string>> graph;
            var shortest = new Dictionary<string, int>();
            foreach (var s in dict)
            {
                if (!shortest.ContainsKey(s))
                    shortest.Add(s, 0);
            }
            //Dictionary<string, string> route = dict.ToDictionary(key => key, _ => string.Empty);
            if (!ConvertToGraph(shortest.Keys.ToArray(), out graph))
                return -1;
            Queue<string> q = new Queue<string>();
            q.Enqueue(start);
            //visited.Add(start);
            unvisited.Remove(start);
            while (q.Count() != 0)
            {
                var vertex = q.Dequeue();
                foreach (var adj in graph[vertex])
                {
                    if (unvisited.Contains(adj))
                    {
                        q.Enqueue(adj);
                        shortest[adj] = shortest[vertex] + 1;
                        //route[adj] = vertex;
                        unvisited.Remove(adj);
                        //visited.Add(adj);
                    }
                }
            }
            return shortest[end] > 0 ? shortest[end] + 1 : 0;
            //if (shortest[end] > 0)
            //{
            //    var node = end;
            //    Console.Write("Route:       ");
            //    while (node != start)
            //    {
            //        Console.Write("{0} <= ", node);
            //        node = route[node];
            //    }
            //    Console.Write(start);
            //    return shortest[end] + 1; //include the starting point itself, or we could increase each layer by 1
            //}
            //else
            //    return 0;
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
                        if (dict[i].Length == dict[j].Length &&
                             Enumerable.Range(0, dict[i].Length).Where(idx => dict[i][idx] != dict[j][idx]).Count() == 1)
                        {
                            graph[dict[i]].Add(dict[j]);
                            graph[dict[j]].Add(dict[i]);
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
            return LadderLength(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize(),
                input.GetToken(2).ToStringArray()).ToString();
        }

        [TestMethod]
        public void Q127_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q127_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
