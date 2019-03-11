using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Keys_and_Rooms
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var seen = new bool[rooms.Count];
            seen[0] = true;
            var stack = new Stack<int>();
            stack.Push(0);

            //At the beginning, we have a todo list "stack" of keys to use.
            //'seen' represents at some point we have entered this room.
            while (stack.Count >0)
            { // While we have keys...
                int node = stack.Pop(); // Get the next key 'node'
                foreach (int nei in rooms[node]) // For every key in room # 'node'...
                    if (!seen[nei])
                    { // ...that hasn't been used yet
                        seen[nei] = true; // mark that we've entered the room
                        stack.Push(nei); // add the key to the todo list
                    }
            }

            
            foreach (bool v in seen)  // if any room hasn't been visited, return false
                if (!v) return false;
            return true;
        }

        
    }

    class Keys_and_Rooms_BFS
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var n = rooms.Count;
            var visited = new HashSet<int>();
            var keys = new Queue<int>();
            visited.Add(0);
            foreach (var key in rooms[0])
            {
                keys.Enqueue(key);
            }
            while (keys.Count > 0)
            {
                var key = keys.Dequeue();
                if (visited.Contains(key)) continue;
                visited.Add(key);
                foreach (var newKey in rooms[key])
                {
                    keys.Enqueue(newKey);
                }
            }
            return visited.Count == n;
        }
    }
}
