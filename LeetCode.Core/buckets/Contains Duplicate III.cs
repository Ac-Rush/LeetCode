using System.Collections.Generic;

namespace Leetcode.buckets
{
    class Contains_Duplicate_III_Bucket
    {
        /*
      We use buckets that t + 1 values will map to. The value of the bucket is the last number placed in the bucket.
We only store k + 1 buckets at a time.
When looking up a value, check which bucket it would go to, and its neighbors. If the buckets have a number, and the difference is within t, we have a solution.
   
    */
        /// <summary>
        /// O（N）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {

            if (k < 1 || t < 0) return false;
            var map = new Dictionary<long, long>();  //《桶，值》
            for (int i = 0; i < nums.Length; i++)
            {
                long remappedNum = (long)nums[i] - int.MinValue;  //或者减去 min也可以

                //按 t+1分桶
                long bucket = remappedNum / ((long)t + 1);
                if (map.ContainsKey(bucket)
                        || (map.ContainsKey(bucket - 1) && remappedNum - map[bucket - 1] <= t)
                            || (map.ContainsKey(bucket + 1) && map[bucket + 1] - remappedNum <= t))
                    return true;
                //去除 K之前的数据
                if (map.Count >= k)
                {
                    long lastBucket = ((long)nums[i - k] - int.MinValue) / ((long)t + 1);
                    map.Remove(lastBucket);
                }
                map[bucket]= remappedNum;
            }
            return false;
        }
    }
}
