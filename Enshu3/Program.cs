using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enshu3
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            //311
            Console.WriteLine("\n-----------3-1-1------------");
            var exists = number.Exists(s => 0 == s / 8);
            Console.WriteLine(exists);

            //312
            Console.WriteLine("-----------3-1-2------------");
            number.ForEach(s => Console.Write("[{0}]", string.Join(", ", s)));
            //Console.WriteLine("[{0}]", string.Join(", ", number));

            //313
            Console.WriteLine("\n-----------3-1-3------------");
            number.Where(s => s >= 50).ToList().ForEach(s=> Console.Write("[{0}]", string.Join(", ", s)));

            //314
            
            Console.WriteLine("\n-----------3-1-4------------");
            List<int> list = new List<int>();
            list = number.Select(s => s *2).ToList();
            Console.WriteLine("[{0}]", string.Join(", ", list));

            Console.WriteLine();

            var names = new List<string>
            {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong kong",
            };

            //321
            Console.WriteLine("\n-----------3-2-1------------");
            Console.Write("入力：");
            var line = Console.ReadLine();
            Console.WriteLine($"{names.FindIndex(s => s == line)}");

            //322
            Console.WriteLine("\n-----------3-2-2------------");
            var a = names.Count(s => s.Contains("s"));
            Console.WriteLine(a);

            //323
            Console.WriteLine("\n-----------3-2-3------------");
            var nam = names.Where(s => s.Contains("o"));
            foreach (var i in nam)
                Console.Write($"[{i}]");

            //324
            Console.WriteLine("\n-----------3-2-4------------");
            names.Where(s => s[0] == 'B').Select(s => s.Length).ToList().ForEach(Console.WriteLine);

        }
    }
}
