using System;

namespace _6._2
{ 
    public interface Test
    {
        int summaryLenght { get; set; }
        void Print();
    }

    class AArray : Test
    {
        public int summaryLenght { get; set; }
        public static object Min(Array array)
        {
            var bufer = (IComparable)array.GetValue(0);

            for (int i = 0; i < array.Length; i++)
                if (bufer.CompareTo(array.GetValue(i)) > 0)
                bufer = (IComparable)array.GetValue(i);
            return bufer;
        }
        public void Print() { Console.WriteLine("  WOW  "); }
    }

    class Program 
    {
        public static void Main()
        {
            Console.WriteLine(Min(new[] {3,6,2,4}));
            Console.WriteLine(Min(new[] {"B","A","C","D"}));
            Console.WriteLine(Min(new[] {'4','2','7'}));
            Console.ReadLine();
        }
    }
}
