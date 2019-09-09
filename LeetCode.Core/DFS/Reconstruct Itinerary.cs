using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.DFS
{
    class Reconstruct_Itinerary
    {
        Dictionary<string, SortedSet<string>> dict = new Dictionary<string, SortedSet<string>>();
        List<string> route = new List<string>();
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            foreach (var ticket in tickets)
            {
                if (!dict.ContainsKey(ticket[0]))
                {
                    dict[ticket[0]] = new SortedSet<string>();
                }
                dict[ticket[0]].Add(ticket[1]);
            }
            return route;
        }
        

        void visit(string airport)
        {
            while (dict.ContainsKey(airport) && dict[airport].Count > 0)
            {
                var min = dict[airport].Min;
                dict[airport].Remove(min);
                visit(min);
            }
            route.Insert(0, airport);
        }
    }
}
