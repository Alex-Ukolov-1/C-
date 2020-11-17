using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_консоль
{
    class Program
    {
        static int[] Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
        static void Main(string[] args)
        {
            int[] arr = { 99, 43, 86 };
            Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            { Console.WriteLine(arr[i]); }
            Console.ReadLine();
        }
    }
}
