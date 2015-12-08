using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Snake
{
    class  Program
    {
         
        static void Main(string[] args)
        {
            StartNewGame();           
        }

        public static void WriteScore(int width, int height, int score) 
        {
            Console.SetCursorPosition(0, height);
            Console.WriteLine("SCORE = " + score);
        }
        
        public static void StartNewGame()
        {
            int score = 0;
            Console.Clear();
            Console.Title = "Snake";
            Screen screen = new Screen(36, 29);
            //создание стен
            Walls walls = new Walls(screen.width, screen.height, '#');

            //создание змейки
            Snake snake = new Snake(new Point (1,1,'@'), 5, Direction.RIGHT);
            snake.Draw();

            //создание еды
            FoodCreator foodCreator = new FoodCreator(screen.width - 1, screen.height - 1, (char)48);
            Point food = foodCreator.GenerateFood(snake);
            food.Draw();

            while (true)
            {
                // если змейка наткналась на еду, то она растет и генерируется новая еда в произвольном месте
                if (snake.IsEat(food))
                {
                    snake.Grow(food);
                    food = foodCreator.GenerateFood(snake);
                    food.Draw();
                    ++score;
                    WriteScore(screen.width, screen.height, score);

                }
                Point head = snake.listPoints.Last<Point>();

                //если змейка наткнулась на свой хвост или на стену, то игра завершается
                if ((snake.IsHitTail()) || (walls.IsHit(snake)))
                {
                    GameOver(screen, score);
                }

                //изменение направления движения змейки с помощью клавиш LEFT, RIGHT, UP и DOWN
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    while (Console.KeyAvailable) key = Console.ReadKey(true);
                    snake.HandleKey(key);
                }
                //задержка движения змейки
                Thread.Sleep(200 - score * 4);
                //само движение змейки
                snake.Move();
            }
            
        }
        public static void GameOver(Screen screen, int score)
        {
            Console.Clear();
            Console.SetCursorPosition(screen.width / 2 - 5, screen.height / 2);
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(screen.width / 2 - 8, screen.height / 2 + 2);
            Console.WriteLine("Your score is " + score);
            Console.SetCursorPosition(0, screen.height - 2);
            Console.WriteLine("For CONTINUE press ENTER");
            Console.WriteLine("For EXIT press ESC ");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    while (Console.KeyAvailable) key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        StartNewGame();
                    }
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
    
}
