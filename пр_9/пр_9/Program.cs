using System;
using System.Drawing;

namespace пр_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter points array size: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int x = 0, y = 0;

            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter {i + 1} point's x: ");
                x = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Enter {i + 1} point's y: ");
                y = Convert.ToInt32(Console.ReadLine());

                points[i] = new Point(x, y);
            }

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(points[i]);
            }

            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;

            double max_distance = 0;
            double current_distance = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    current_distance = Math.Sqrt((points[i].X - points[j].X) * (points[i].X - points[j].X) + (points[i].Y - points[j].Y) * (points[i].Y - points[j].Y));
                    if (current_distance > max_distance)
                    {
                        max_distance = current_distance;

                        x1 = points[i].X;
                        y1 = points[i].Y;

                        x2 = points[j].X;
                        y2 = points[j].Y;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Max distance between P1({x1}, {y1}) and P1({x2}, {y2}) is {Math.Round(max_distance, 3)}");
        }
    }
}
