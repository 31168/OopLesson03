using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2 - 4, 8, -1, 6, 4 };
            Console.WriteLine($"平均値：{numbers.Average()}");
            Console.WriteLine($"合計値：{numbers.Sum()}");
            Console.WriteLine($"最小値：{numbers.Where(n => n > 0).Min()}");
            Console.WriteLine($"最大値；{numbers.Max()}");

            var books = Books.GetBooks();

            var number = new List<int> { 8, 20, 15, 48, 2 };
            var strings = number.Select(n => n.ToString("0000")).ToArray();
            foreach(var i in strings)
            {
                Console.WriteLine(i);
            }
        }

    }
}
