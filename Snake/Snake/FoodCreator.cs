using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        int width;
        int height;
        char symbol;
        Random random;
        public FoodCreator(int width, int height, char symbol)
        {
            random = new Random();
            this.width = width;
            this.height = height;
            this.symbol = symbol;
        }
        public Point GenerateFood(Snake snake)
        {
            while (true)
            {
                int randX = random.Next(1, width - 1);
                int randY = random.Next(1, height - 1);
                bool flag = false;
                // проверяем, не попала ли еда на змейку
                foreach (Point point in snake.listPoints)
                {
                    if ((point.x == randX) && (point.y) == randY)
                    {
                        flag = true;
                    }
                }
                if (flag == false) return new Point(randX, randY, symbol);
            }                   
        }
    }
}
