using System;
using System.Collections.Generic;

namespace _6._3
{
    public interface Test
    {
        int summaryLenght { get; set; }
        void Print();
    }

    public class Book:IComparable<Book>,Test
    {
        public int summaryLenght{get;set;}
        public string Title { get; set; }
        public int Theme { get; set; }
        public Book(string name)
        {
            Title=name;
        }

        public int CompareTo(Book other)
        {
            return Title.CompareTo(other.Title);
        }
        public void Print() { Console.WriteLine("Конец первого блока"); }
    }

    public class Program:Test
    {
        public int summaryLenght { get; set; }
        public void Print() { Console.WriteLine("проверка на поиск ошибок"); }
        static void Main()
        {
            List<Book> mebooks = new List<Book>
            {new Book("Alan Rouse "+34+" pages"),new Book("Genry Herd " + 23+" pages"),new Book("John Lenon " + 98+" pages"),new Book("Bernard Oushen "+21+" pages" ),new Book("Clint Istwood "+94+" pages" ),new Book("Daniel DEFO "+94+" pages" )};
            mebooks.Sort();
            mebooks.ForEach(Book => Console.WriteLine(Book.Title));
            Console.ReadKey();

        }
    }
}
