using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Shape 
    {
        public List<Point> listPoints;
        public void Draw()
        {
            foreach (Point point in listPoints)
            {
                point.Draw();
            }
        }

       
    }
}
