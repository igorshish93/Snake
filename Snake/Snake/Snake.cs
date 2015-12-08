using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
   public  enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    };

    public class Snake : Shape
    {
        public Direction direction;

        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            listPoints = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point point = new Point(tail);
                point.Move(i, direction);
                listPoints.Add(point);
            }
        }
        internal void Move()
        {
            Point tail = listPoints.First<Point>();
            listPoints.Remove(tail);
            Point head = GetNextPoint();
            listPoints.Add(head);
            tail.Clear();
            head.Draw();
        }
        public Point GetNextPoint()
        {
            Point head = listPoints.Last<Point>();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        public void HandleKey(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case (ConsoleKey.LeftArrow):
                    {
                        if ((direction != Direction.RIGHT) && (direction != Direction.LEFT))
                        {
                            direction = Direction.LEFT;
                        }
                        break;
                    }
                case (ConsoleKey.RightArrow):
                    {
                        if ((direction != Direction.RIGHT) && (direction != Direction.LEFT))
                        {
                            direction = Direction.RIGHT;
                        }
                        break;
                    }
                case (ConsoleKey.UpArrow):
                    {
                        if ((direction != Direction.UP) && (direction != Direction.DOWN))
                        {
                            direction = Direction.UP;
                        }
                        break;
                    }
                case (ConsoleKey.DownArrow):
                    {
                        if ((direction != Direction.UP) && (direction != Direction.DOWN))
                        {
                            direction = Direction.DOWN;
                        }

                        break;
                    }
            }
        }
        public bool IsEat(Point food)
        {
            Point head = listPoints.Last<Point>();
            if ((head.x == food.x) && (head.y == food.y))
            {
                return true;
            }
            else return false;
        }
        public void Grow(Point food)
        {
            Point tail = listPoints[0];
            Point preTail = listPoints[1];
            if (tail.x == preTail.x){
                if (tail.y < preTail.y)
                {
                    DrawNewTail(tail.x, tail.y - 1, tail.symbol);
                }
                else if (tail.y > preTail.y)
                {
                    DrawNewTail(tail.x, tail.y + 1, tail.symbol);
                }

            }
            else if (tail.y == preTail.y)
            {
                if (tail.x < preTail.x)
                {
                    DrawNewTail(tail.x - 1, tail.y, tail.symbol);
                }
                else if (tail.x > preTail.x)
                {
                    DrawNewTail(tail.x + 1, tail.y, tail.symbol);
                }
            }
                                
        }
        public void DrawNewTail(int x, int y, char symbol)
        {
            Point tail = new Point(x, y, symbol);
            listPoints.Insert(0, tail);
            tail.Draw();
        }
        public bool IsHitTail()
        {
            Point head = listPoints.Last<Point>();
            for (int i = 0; i < listPoints.Count - 1; i++)
            {
                if ((head.x == listPoints[i].x) && (head.y == listPoints[i].y))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
