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
        /// <summary>
        /// Easy BFS Topological sort, Java
        /// BFS 拓扑排序， sort
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            var matrix = new int[numCourses,numCourses]; // i -> j
            int[] indegree = new int[numCourses];

            //构建有向图， 并且统计入度
            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                int ready = prerequisites[i,0];
                int pre = prerequisites[i,1];
                if (matrix[pre,ready] == 0)
                    indegree[ready]++; //duplicate case  增加入度
                matrix[pre,ready] = 1;
            }

            int count = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < indegree.Length; i++)
            {
                //把 0入度的添加到 Queue里
                if (indegree[i] == 0) queue.Enqueue(i);
            }
            while (queue.Any())
            {
                //取出 0入度的课程
                int course = queue.Dequeue();
                count++; //这个课没有 前序， 所以课程+1
                for (int i = 0; i < numCourses; i++)
                {
                    //遍历所有课， 如果有 课程i需要 course为前缀
                    if (matrix[course,i] != 0)
                    {
                        //那么把课程i的前缀 减一
                        if (--indegree[i] == 0)
                            //把 入度为0的加入queue.
                            queue.Enqueue(i);
                    }
                }
            }
            //返回是不是遍历了需要的课程
            return count == numCourses;
        }
    }
}
