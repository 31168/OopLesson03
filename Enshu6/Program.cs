using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Enshu6
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            var books = new List<Book>
            {
                new Book {Title = "C#プログラミングの新常識",Price =3800,Pages = 378},
                new Book {Title = "ラムダ式とLINQの極意",Price = 2500 ,Pages = 312},
                new Book {Title = "ワンダフル・C#ライフ",Price = 2900,Pages = 385},
                new Book {Title = "一人で学ぶ並列処理プログラミング",Price = 4800,Pages = 464},
                new Book {Title = "フレーズで覚えるC#入門",Price = 5300,Pages = 604 },
                new Book {Title = "私でも分かったASP.NET MVC",Price = 3200,Pages = 453},
                new Book {Title = "楽しいC#プログラミング教室",Price = 2540,Pages = 348}
            };

            books.Add(new Book { Title})

            Console.WriteLine("\n-----------1-1------------");
            Console.WriteLine($"最大値　= {numbers.Max()}");

            Console.WriteLine("\n-----------1-2------------");
            numbers.Reverse().Take(2).ToList().ForEach(n => Console.Write($"[{n}] "));

            Console.WriteLine("\n-----------1-3------------");
            numbers.Select(n => n.ToString("00")).ToList().ForEach(n => Console.Write($"[{n}]"));

            Console.WriteLine("\n-----------1-4------------");
            numbers.OrderBy(n => n).Take(3).ToList().ForEach(n => Console.Write($"[{n}]"));

            Console.WriteLine("\n-----------1-5------------");
            Console.WriteLine($"１０より多き数字:{ numbers.Distinct().Count(n => n > 10)}");





            Console.WriteLine("\n-----------2-1------------");
            Console.WriteLine($"ワンダフルの価格：{books.Where(n => n.Title == "ワンダフル・C#ライフ").Select(n => n.Price)}");
            Console.WriteLine($"ワンダフルのページ数：{books.Where(n => n.Title == "ワンダフル・C#ライフ").Select(n => n.Pages)}");


            Console.WriteLine("\n-----------2-2------------");
            var count = books.Count(n => n.Title.Contains("C#"));
            Console.WriteLine(count);


            Console.WriteLine("\n-----------2-3------------");
            var avg = books.Where(n => n.Title
                            .Contains("C#"))
                            .Select(n => n.Pages)
                            .ToList()
                            .Average();
            Console.WriteLine(avg);


            Console.WriteLine("\n-----------2-4------------");
            Console.WriteLine( books.FirstOrDefault(n => n.Price >= 4000).Title);


            Console.WriteLine("\n-----------2-5------------");
            var a = books.Where(n => n.Price < 4000)
                            .Max(n => n.Pages);
            Console.WriteLine(a);


            Console.WriteLine("\n-----------2-6------------");
            var b = books.Where(n => n.Pages >= 400)
                            .OrderByDescending(n => n.Pages)
                            .ToArray();
                            
            foreach(var n in b)
            {
                Console.WriteLine($"Price : {n.Price} ,Title : {n.Title} ");
            }


            Console.WriteLine("\n-----------2-7------------");
            var c = books.Where(n => n.Title.Contains("C#"))
                            .Where(n => n.Pages <= 500);
            foreach (var n in c)
            {
                Console.WriteLine(n.Title);
            }
        }
    }
}
