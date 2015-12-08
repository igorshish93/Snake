using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HorizontalLine : Shape
    {

        public HorizontalLine(int x1, int x2, int y, char symbol)
        {
            listPoints = new List<Point>();
            for (int x = x1; x <= x2; x++)
            {
                listPoints.Add(new Point(x, y, symbol));
            }
        }


    }
}
