using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine : Shape
    {
        public VerticalLine(int x, int y1, int y2, char symbol)
        {
            listPoints = new List<Point>();
            for (int y = y1; y <= y2; y++)
            {
                listPoints.Add(new Point(x, y, symbol));
            }
        }
    }
}
