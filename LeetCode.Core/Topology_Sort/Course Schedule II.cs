using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Topology_Sort
{
    class Course_Schedule_II
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var graph = new int[numCourses, numCourses];
            var ans =  new List<int>();
            var inDegree = new int[numCourses];
            foreach (var prerequisite in prerequisites)
            {
                var ready = prerequisite[0];
                var pre = prerequisite[1];
                graph[pre, ready] = 1;
                inDegree[ready]++;
            }
            var queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if(inDegree[i] == 0) queue.Enqueue(i);
            }
            while (queue.Any())
            {
                var course = queue.Dequeue();
                ans.Add(course);
                for (int i = 0; i < numCourses; i++)
                {
                    if (graph[course, i] == 1)
                    {
                        if(--inDegree[i] == 0) queue.Enqueue(i);
                    }
                }
            }

            return ans.Count == numCourses? ans.ToArray(): new int[0]; // my bug， 如果没有答案 返回 int[0]
        }
    }
}
