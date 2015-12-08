using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Walls
    {
        public List<Shape> listOfWalls;
        public Walls(int width, int height, char symbol)
        {
            listOfWalls = new List<Shape>();
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.SetBufferSize(width, height + 2);
            Console.SetWindowSize(width, height + 2);
            HorizontalLine lineTop = new HorizontalLine(0, width - 2, 0, symbol);
            HorizontalLine lineBottom = new HorizontalLine(0, width - 2, height - 1, symbol);
            VerticalLine lineLeft = new VerticalLine(0, 0, height - 1, symbol);
            VerticalLine lineRight = new VerticalLine(width - 1, 0, height - 2, symbol);
            listOfWalls.Add(lineTop);
            listOfWalls.Add(lineBottom);
            listOfWalls.Add(lineLeft);
            listOfWalls.Add(lineRight);
            lineTop.Draw();
            lineBottom.Draw();
            lineLeft.Draw();
            lineRight.Draw();
            Program.WriteScore(width, height, 0);
        }
        public bool IsHit(Snake snake)
        {
            Point head = snake.listPoints.Last<Point>();
            foreach (Shape wall in listOfWalls)
            {
                for (int i = 0; i < wall.listPoints.Count; i++)
                {
                    if ((head.x == wall.listPoints[i].x) && (head.y == wall.listPoints[i].y))
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
