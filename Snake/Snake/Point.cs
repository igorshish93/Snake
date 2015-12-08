using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public char symbol { get; set; }
        public Point(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }
        public Point(Point point)
        {
            this.x = point.x;
            this.y = point.y;
            this.symbol = point.symbol;
        }
        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case (Direction.LEFT): this.x -= offset; break;
                case (Direction.RIGHT): this.x += offset; break;
                case (Direction.DOWN): this.y += offset; break;
                case (Direction.UP): this.y -= offset; break;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.symbol);
        }
        public void Clear()
        {
            symbol = ' ';
            Draw();
        }
    }
}
