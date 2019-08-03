using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{
    class Course_Schedule_III
    {
        public int ScheduleCourse(int[][] courses)
        {
            System.Array.Sort(courses, (a, b)=>a[1] - b[1]); //Sort the courses by their deadlines (Greedy! We have to deal with courses with early deadlines first)
            //PriorityQueue<Integer> pq = new PriorityQueue<>((a, b)->b - a);
            var pq = new SortedSet<int[]>(Comparer<int[]>.Create( (a,b)=>
            {
                if (a[0] != b[0])
                {
                    return a[0] - b[0];
                }
                return a[1] - b[1];
            }));
            int time = 0;
            for (int i = 0; i < courses.Length; i++)
            {
                time += courses[i][0]; // add current course to a priority queue
                pq.Add(new[] {courses[i][0], i});

                // 如果不满足，就删掉课程时间最长的， 也许是自己
                 if (time > courses[i][1])
                 {
                     var max = pq.Max;
                     pq.Remove(max);
                     time -= max[0]; //If time exceeds, drop the previous course which costs the most time. (That must be the best choice!)
                 }
            }
           
            return pq.Count;
        }
    }
}
