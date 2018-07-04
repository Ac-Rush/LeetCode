using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    public class Robot_Room_Cleaner
    {
        public interface Robot
        {
     // Returns true if the cell in front is open and robot moves into the cell.
      // Returns false if the cell in front is blocked and robot stays in the current cell.
            bool Move();
 
      // Robot will stay in the same cell after calling turnLeft/turnRight.
      // Each turn will be 90 degrees.
       void TurnLeft();
       void TurnRight();
 
      // Clean the current cell.
       void Clean();
  }

        HashSet<String> cleaned;
        enum Directions { NORTH, SOUTH, EAST, WEST };
        Directions direction;
        Robot robot;

        public void CleanRoom(Robot robot)
        {
            direction = Directions.NORTH;
            cleaned = new HashSet<string>();
            this.robot = robot;
            visit(0, 0, robot);
        }

        private void visit(int x, int y, Robot robot)
        {
            if (cleaned.Contains(x + "." + y))
            {
                return;
            }
            robot.Clean();
            cleaned.Add(x + "." + y);

            //System.out.println("x = " + x + ", y = " + y);
            //System.out.println(cleaned);
            //System.out.println(direction);

            turnNorth();
            if (robot.Move())
            {
                visit(x - 1, y, robot);
                turnSouth();
                robot.Move();
            }
            turnSouth();
            if (robot.Move())
            {
                visit(x + 1, y, robot);
                turnNorth();
                robot.Move();
            }
            turnEast();
            if (robot.Move())
            {
                visit(x, y + 1, robot);
                turnWest();
                robot.Move();
            }
            turnWest();
            if (robot.Move())
            {
                visit(x, y - 1, robot);
                turnEast();
                robot.Move();
            }
        }

        private void turnNorth()
        {
            switch (direction)
            {
                case Directions.NORTH:
                    break;
                case Directions.SOUTH:
                    robot.TurnLeft();
                    robot.TurnLeft();
                    break;
                case Directions.EAST:
                    robot.TurnLeft();
                    break;
                case Directions.WEST:
                    robot.TurnRight();
                    break;
            }
            direction = Directions.NORTH;
        }

        private void turnSouth()
        {
            switch (direction)
            {
                case Directions.NORTH:
                    robot.TurnLeft();
                    robot.TurnLeft();
                    break;
                case Directions.SOUTH:
                    break;
                case Directions.EAST:
                    robot.TurnRight();
                    break;
                case Directions.WEST:
                    robot.TurnLeft();
                    break;
            }
            direction = Directions.SOUTH;
        }

        private void turnEast()
        {
            switch (direction)
            {
                case Directions.NORTH:
                    robot.TurnRight();
                    break;
                case Directions.SOUTH:
                    robot.TurnLeft();
                    break;
                case Directions.EAST:
                    break;
                case Directions.WEST:
                    robot.TurnLeft();
                    robot.TurnLeft();
                    break;
            }
            direction = Directions.EAST;
        }

        private void turnWest()
        {
            switch (direction)
            {
                case Directions.NORTH:
                    robot.TurnLeft();
                    break;
                case Directions.SOUTH:
                    robot.TurnRight();
                    break;
                case Directions.EAST:
                    robot.TurnLeft();
                    robot.TurnLeft();
                    break;
                case Directions.WEST:
                    break;
            }
            direction = Directions.WEST;
        }
    }
}
