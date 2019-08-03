using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    /// <summary>
    /// wrong
    /// </summary>
    public class SnakeGame
    {
        //2D position info is encoded to 1D and stored as two copies 
        HashSet<int> set; // this copy is good for fast loop-up for eating body case
        Queue<int> body; // this copy is good for updating tail
        int score;
        int[,] food;
        int foodIndex;
        int width;
        int height;
        /** Initialize your data structure here.
            @param width - screen width
            @param height - screen height 
            @param food - A list of food positions
            E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
        public SnakeGame(int width, int height, int[,] food)
        {
            this.width = width;
            this.height = height;
            this.food = food;
            set = new HashSet<int> {0};
            //intially at [0][0]
            body = new Queue<int>();
            body.Enqueue(0);
        }

        /** Moves the snake.
            @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
            @return The game's score after the move. Return -1 if game over. 
            Game over when snake crosses the screen boundary or bites its body. */
        public int Move(string direction)
        {
            //case 0: game already over: do nothing
            if (score == -1)
            {
                return -1;
            }

            // compute new head
            int rowHead = body.First() / width;
            int colHead = body.First() % width;
            switch (direction)
            {
                case "U":
                    rowHead--;
                    break;
                case "D":
                    rowHead++;
                    break;
                case "L":
                    colHead--;
                    break;
                default:  colHead++;
                    break;
            }
            int head = rowHead * width + colHead;

            //case 1: out of boundary or eating body
            set.Remove(body.Last()); // new head is legal to be in old tail's position, remove from set temporarily 
            if (rowHead < 0 || rowHead == height || colHead < 0 || colHead == width || set.Contains(head))
            {
                return score = -1;
            }

            // add head for case2 and case3
            set.Add(head);
            body.Enqueue(head);

            //case2: eating food, keep tail, add head
            if (foodIndex < food.GetLength(0) && rowHead == food[foodIndex,0] && colHead == food[foodIndex,1])
            {
                set.Add(body.Last()); // old tail does not change, so add it back to set
                foodIndex++;
                return ++score;
            }

            //case3: normal move, remove tail, add head
            body.Dequeue();
            return score;
        }
    }
}
