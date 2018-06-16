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
}
