using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace объяснение_объекта_умным_человеком
{
    public class Star
    {
       public int x, y, vx, vy;

        public void move()
        {
            x += vx;
            y += vy;
            if (x >= 70 || x <= 1) vx = -vx;
            if (y >= 20 || y <= 1) vy = -vy;
        }

        public void show()
        {
            Console.SetCursorPosition(x,y);
            Console.Write("*");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Star star1;
            star1 = new Star();
            star1.x = 40;
            star1.y = 10;
            star1.vx = 1;
            star1.vy = 1;
            do
            {
                star1.move();
                star1.show();
                System.Threading.Thread.Sleep(100);
                Console.Clear();
            }
            while (!Console.KeyAvailable);
            Console.ReadKey();
        }
    }
}
