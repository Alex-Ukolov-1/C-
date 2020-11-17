using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using работа_1;

namespace работа_1
{

    public class ClassData
    {
       
        static public double GetPressure(int To, int Dt)
        {
            Console.WriteLine("введите давление");
            To = Int32.Parse(Console.ReadLine());
            Console.WriteLine("введите температуру газа");
            Dt = Int32.Parse(Console.ReadLine());
            double bb = 8 * Math.Pow(10, 5) * To / Dt;
            Console.WriteLine("рассчёт");
            return (bb);
        }

        static public double Amountofmatter()
        {
            Console.WriteLine("введите колличество вещества");
            int sad = Int32.Parse(Console.ReadLine());
            return (sad);
        }

        public string Tostring()
        {
            string sad = (Console.ReadLine());
            return (sad);
        }
    }
    // Представляет фасадные объекты
    public class adapter
    {
        ClassData b;
        public adapter()
        {

            b = new ClassData();
        }
        static public double CalculateDP(int To, int Dt)
        {
            double ren = To * Math.Sqrt(Dt);
            return (ren);
        }
         public void ModifMass(double mass)
        {
            Console.WriteLine("введите массу газа без баллона");
            int n = Int32.Parse(Console.ReadLine());
        }
        static public string GetData()
        {
          
            Console.WriteLine("введите массу газа в баллоне");
            int n = Int32.Parse(Console.ReadLine());
            return ("данные об объекте:вес =" + n);
        }

        public void F1()
        {
            Console.WriteLine("введите массу газа в баллоне");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine(ClassData.GetPressure(10,5) + "\n"+ ClassData.Amountofmatter()+"\n"+ adapter.CalculateDP(15,28)+"\n"+ adapter.GetData());
        }
    }
        // Клиент
        class Client
        {
            static void Main(string[] args)
            {
            Console.WriteLine("введите массу баллона");
            int n = Int32.Parse(Console.ReadLine());
            adapter facade = new adapter();
                facade.F1();
                facade.ModifMass(n);
                Console.Read();
            }
        }
    }
