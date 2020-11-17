using System;
using System.Collections.Generic;

namespace _6._4
{
    class Program
    {
        static void Main(string[] args)
        {
            CompInv<Point> cp = new CompInv<Point>();
            List<Point> dic = new List<Point>();

            dic.Add(new Point { X = 1, Y = 0 });
            dic.Add(new Point { X = -1, Y = 0 });
            dic.Add(new Point { X = 0, Y = 1 });
            dic.Add(new Point { X = 0, Y = -1 });
            dic.Add(new Point { X = 0.01, Y = 1 });

            dic.Sort(cp);
            foreach (Point e in dic)
                Console.WriteLine("{0} {1}", e.X, e.Y);
        }
    }
    public class Point
    {
        public double X;
        public double Y;
    }
    public class CompInv<T> : IComparer<T>
        where T : Point
    {
        public int Compare(T x, T y)
        {
            return Math.Atan2(-x.Y, -x.X).CompareTo(Math.Atan2(-y.Y, -y.X));
        }
    }
}
