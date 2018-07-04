using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{
    class Course_Schedule
    {
        //明天好好看看
        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            var matrix = new int[numCourses,numCourses]; // i -> j
            int[] indegree = new int[numCourses];

            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                int ready = prerequisites[i,0];
                int pre = prerequisites[i,1];
                if (matrix[pre,ready] == 0)
                    indegree[ready]++; //duplicate case
                matrix[pre,ready] = 1;
            }

            int count = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0) queue.Enqueue(i);
            }
            while (queue.Any())
            {
                int course = queue.Dequeue();
                count++;
                for (int i = 0; i < numCourses; i++)
                {
                    if (matrix[course,i] != 0)
                    {
                        if (--indegree[i] == 0)
                            queue.Enqueue(i);
                    }
                }
            }
            return count == numCourses;
        }
    }
}
