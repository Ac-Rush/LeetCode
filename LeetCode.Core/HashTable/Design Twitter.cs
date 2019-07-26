using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Helper;

namespace Leetcode.HashTable
{
    
    public class Twitter
    {
        private static int timeStamp = 0;

        // easy to find if user exist
        private Dictionary<int, User> userMap;

        /** Initialize your data structure here. */
        public Twitter()
        {
            userMap = new Dictionary<int, User>();
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (!userMap.ContainsKey(userId))
            {
                User u = new User(userId);
                userMap[userId]= u;
            }
            userMap[userId].post(tweetId);
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        // Best part of this.
        // first get all tweets lists from one user including itself and all people it followed.
        // Second add all heads into a max heap. Every time we poll a tweet with 
        // largest time stamp from the heap, then we add its next tweet into the heap.
        // So after adding all heads we only need to add 9 tweets at most into this 
        // heap before we get the 10 most recent tweet.
        public IList<int> GetNewsFeed(int userId)
        {
            List<int> res = new List<int>();

            if (!userMap.ContainsKey(userId)) return res;

            var users = userMap[userId].followed;
            var queue = new SortedList<int, Tweet>(new DuplicateKeyComparer<int>());
            foreach (int user in users)
            {
                Tweet t = userMap[user].tweet_head;
                // very imporant! If we add null to the head we are screwed.
                if (t != null)
                {
                    queue.Add(t.time, t);
                  //  queue[t.time] = t;
                }
            }
            int n = 0;
            while (queue.Count > 0 && n < 10)
            {
                Tweet t = queue.First().Value;
                res.Add(t.id);
                queue.RemoveAt(0);
                n++;
               if (t.next != null)
                    queue.Add(t.next.time, t.next);
            }

            return res;
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (!userMap.ContainsKey(followerId))
            {
                User u = new User(followerId);
                userMap[followerId] = u;
            }
            if (!userMap.ContainsKey(followeeId))
            {
                User u = new User(followeeId);
                userMap[followeeId] = u;
            }
            userMap[followerId].follow(followeeId);
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (!userMap.ContainsKey(followerId) || followerId == followeeId)
                return;
            userMap[followerId].unfollow(followeeId);
        }

        public class User
        {
            public int id;
            public HashSet<int> followed;
            public Tweet tweet_head;

            public User(int id)
            {
                this.id = id;
                followed = new HashSet<int>();
                follow(id); // first follow itself
                tweet_head = null;
            }

            public void follow(int id)
            {
                followed.Add(id);
            }

            public void unfollow(int id)
            {
                followed.Remove(id);
            }


            // everytime user post a new tweet, add it to the head of tweet list. //放到队头
            public void post(int id)
            {
                Tweet t = new Tweet(id);
                t.next = tweet_head;
                tweet_head = t;
            }
        }

        // Tweet link to next Tweet so that we can save a lot of time
        // when we execute getNewsFeed(userId)
        public class Tweet
        {
            public int id;
            public int time;
            public Tweet next;

            public Tweet(int id)
            {
                this.id = id;
                time = timeStamp++;
                next = null;
            }
        }
    }

    /**
     * Your Twitter object will be instantiated and called as such:
     * Twitter obj = new Twitter();
     * obj.PostTweet(userId,tweetId);
     * IList<int> param_2 = obj.GetNewsFeed(userId);
     * obj.Follow(followerId,followeeId);
     * obj.Unfollow(followerId,followeeId);
     */
}
