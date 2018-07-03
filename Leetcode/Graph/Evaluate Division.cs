using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{
    class Evaluate_Division
    {
        /// <summary>
        ///  1 构建 双向图   Dictionary<string, Dictionary<string, double>>
        ///  2. 求解每一个 query
        /// </summary>
        /// <param name="equations"></param>
        /// <param name="values"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
        {
            // build undirected graph lookup
            Dictionary<string, Dictionary<string, double>> nodes = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < equations.GetLength(0); i++)
            {
                string e0 = equations[i, 0];
                string e1 = equations[i, 1];
                if (!nodes.ContainsKey(e0)) nodes[e0] = new Dictionary<string, double>();
                if (!nodes.ContainsKey(e1)) nodes[e1] = new Dictionary<string, double>();
                nodes[e0][e1] = values[i];
                nodes[e1][e0] = 1.0 / values[i];
            }

            double[] res = new double[queries.GetLength(0)];
            for (int i = 0; i < queries.GetLength(0); i++)
            {
                res[i] = Solve(queries[i, 0], queries[i, 1], nodes);
            }

            return res;
        }

        // use -1 to signal fail, given the constraints of this problem that will be okay
        public double Solve(string e0, string e1, Dictionary<string, Dictionary<string, double>> allNodes)
        {
            if (!allNodes.ContainsKey(e0) || !allNodes.ContainsKey(e1)) return -1;
            if (e0 == e1) return 1.0;

            double res = 1;
            Dictionary<string, double> e0Nodes = allNodes[e0];

            // remove to prevent using this node again
            allNodes.Remove(e0);

            // DFS - search all children
            foreach (string n in e0Nodes.Keys)
            {
                res = Solve(n, e1, allNodes);
                if (res != -1)
                {
                    res *= e0Nodes[n];
                    break;
                }
            }

            // backtracking - add back in
            allNodes[e0] = e0Nodes;

            return res;
        }
    }


   
}
