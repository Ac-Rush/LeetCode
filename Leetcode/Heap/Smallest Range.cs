using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
    /// <summary>
    /// 这样的循环比较好理解
    /// </summary>
    class Smallest_Range_1
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            //minx , miny 是 范围的两端   minx不能取 负无穷，要不以后容易越界
            int minx = 0, miny = int.MaxValue, max = int.MinValue;
            int[] next = new int[nums.Count];   //next 数组  next[0] 就是第0个数组的 下一个index
            var minQueue = // java 里面用 PQ, C# 里面用的SortedSet 来模拟，但是 SortedSet不支持重复， 还好这里可以用 数组的index来当做第二个维度去重
                new SortedSet<int>(Comparer<int>.Create((x, y) =>
                {
                    var result = nums[x][next[x]].CompareTo(nums[y][next[y]]);
                    if (result == 0)  //如果有重复，那么就根据 行号排， 第一组数的在前面
                    {
                        return x.CompareTo(y);
                    }
                    return result;
                }
                    ));
            for (int i = 0; i < nums.Count; i++)
            {
                minQueue.Add(i);  //初始化 QP， 每行数组 第一个数加入PQ
                max = Math.Max(max, nums[i][0]); // 并且找到最大值
            }
            while (minQueue.Count == nums.Count)
            {
                int min_i = minQueue.Min;
                minQueue.Remove(min_i);
                if (miny - minx > max - nums[min_i][next[min_i]])  //如果 range 大于了，  目前的最大值 减去 最小值 ， 那么更新 range
                {
                    minx = nums[min_i][next[min_i]];
                    miny = max;
                }
                next[min_i]++;  //把刚才删除的最小值的那个数组 向后移动一位
                if (next[min_i] == nums[min_i].Count) //check 退出条件
                {
                    break;
                }
                minQueue.Add(min_i);  //把 刚才数组的下一个加进来
                max = Math.Max(max, nums[min_i][next[min_i]]);  //更新当前的max
            }
            return new int[] { minx, miny };
        }

    }


    /// <summary>
    /// 经典题目， 利用了堆， 用 sortedset来模拟
    /// </summary>
    class Smallest_Range_2
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            //minx , miny 是 范围的两端
            int minx = 0, miny = int.MaxValue, max = int.MinValue;
            int[] next = new int[nums.Count];   //next 数组  next[0] 就是第0个数组的 下一个index
            var flag = true; //退出循环标识符
            var minQueue = // java 里面用 PQ, C# 里面用的SortedSet 来模拟，但是 SortedSet不支持重复， 还好这里可以用 数组的index来当做第二个维度去重
                new SortedSet<int>(Comparer<int>.Create((x, y) =>
                {
                    var result = nums[x][next[x]].CompareTo(nums[y][next[y]]);
                    if (result == 0)  //如果有重复，那么就根据 行号排， 第一组数的在前面
                    {
                        return x.CompareTo(y);
                    }
                    return result;
                }
                    ));
            for (int i = 0; i < nums.Count; i++)
            {
                minQueue.Add(i);  //初始化 QP， 每行数组 第一个数加入PQ
                max = Math.Max(max, nums[i][0]); // 并且找到最大值
            }
            for (int i = 0; i < nums.Count && flag; i++)
            {
                for (int j = 0; j < nums[i].Count && flag; j++)
                {
                    int min_i = minQueue.Min;
                    minQueue.Remove(min_i);
                    if (miny - minx > max - nums[min_i][next[min_i]])
                    {
                        minx = nums[min_i][next[min_i]];
                        miny = max;
                    }
                    next[min_i]++;
                    if (next[min_i] == nums[min_i].Count)
                    {
                        flag = false; //某一个已经到达最后了， 退出
                        break;
                    }
                  
                    minQueue.Add(min_i);
                    max = Math.Max(max, nums[min_i][next[min_i]]);
                }
            }
            return new int[] { minx, miny };
        }
        
    }
}
