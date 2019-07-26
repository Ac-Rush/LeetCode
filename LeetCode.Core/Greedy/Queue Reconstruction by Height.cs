using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Greedy
{
    /// <summary>
    /// 贪心算法，  
    /// 1. 按照身高 先从高到低， 再按位置排序，
    /// 2. 按上面的顺序，一次插入到 temp结果里，按照 位置来插入
    /// </summary>
    class Queue_Reconstruction_by_Height
    {
        public int[,] ReconstructQueue(int[,] people)
        {
            List<Tuple<int, int>> temp = new List<Tuple<int, int>>();
            List<Tuple<int, int>> temp2 = new List<Tuple<int, int>>(people.GetLength(0));
            for (int k = 0; k < people.GetLength(0); k++)
            {
                temp.Add(new Tuple<int, int>(people[k, 0], people[k, 1]));
            }
            //sort the numbers first by height and then by the position. height in descending order and position in ascending order.
            temp.Sort((x, y) => { int result = y.Item1.CompareTo(x.Item1); return result == 0 ? x.Item2.CompareTo(y.Item2) : result; });
            for (int i = 0; i < temp.Count; i++)
            {
                temp2.Insert(temp[i].Item2, temp[i]);
            }
            for (int l = 0; l < people.GetLength(0); l++)
            {
                people[l, 0] = temp2[l].Item1;
                people[l, 1] = temp2[l].Item2;
            }
            //place the result back in original 2d array
            return people;
        }
    }


    class Queue_Reconstruction_by_Height_orderby
    {
        public int[,] ReconstructQueue(int[,] people)
        {
            List<Tuple<int, int>> temp = new List<Tuple<int, int>>();
            List<Tuple<int, int>> temp2 = new List<Tuple<int, int>>(people.GetLength(0));
            for (int k = 0; k < people.GetLength(0); k++)
            {
                temp.Add(new Tuple<int, int>(people[k, 0], people[k, 1]));
            }
            //sort the numbers first by height and then by the position. height in descending order and position in ascending order.
            var temp3 = temp.OrderByDescending(x => x.Item1).ThenBy(x => x.Item2).ToList();
         
            for (int i = 0; i < temp.Count; i++)
            {
                temp2.Insert(temp3[i].Item2, temp3[i]);
            }
            for (int l = 0; l < people.GetLength(0); l++)
            {
                people[l, 0] = temp2[l].Item1;
                people[l, 1] = temp2[l].Item2;
            }
            //place the result back in original 2d array
            return people;
        }
    }
}
