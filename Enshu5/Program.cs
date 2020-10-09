using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enshu5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n-----------5-1------------");
            Console.Write("文字列１：");
            var str1 = Console.ReadLine();
            Console.Write("文字列２：");
            var str2 = Console.ReadLine();
            if (String.Compare(str1, str2,ignoreCase: true) == 0)
                Console.WriteLine("等しい");
            else
                Console.WriteLine("等しくない");

            Console.WriteLine("\n-----------5-2------------");
            var str = int.Parse( Console.ReadLine());
            Console.WriteLine($"{$"{str:#,0}"}");

            Console.WriteLine("\n-----------5-3-1------------");
            var sump = "Jackdaws love my big sphinx of quartz";
            Console.WriteLine("空白がいくつ");
            Console.WriteLine(sump.Count(c => c ==  ' '));

            Console.WriteLine("\n-----------5-3-2------------");
            var rep = sump.Replace("big", "small");

            Console.WriteLine("\n-----------5-3-3------------");
            var count = sump.Split(' ').Count();

            Console.WriteLine("\n-----------5-3-4------------");
            var text = sump.Split(' ');
            var sum = text.Where(s => s.Length <= 4);

            Console.WriteLine("\n-----------5-3-5------------");

            var array = sump.Split(' ').ToArray();
            if (array.Length > 0)
            {
                var sb = new StringBuilder(array[0]);
                foreach(var word in array.Skip(1))
                {
                    sb.Append(' ');
                    sb.Append(word);
                }
                Console.WriteLine(sb);
                
            }

            Console.WriteLine("\n-----------5-4------------");
            var tex = "Novelist=谷崎純一郎;BestWork=春琴;Born=1886";
            var words = tex.Split(';');
            foreach (var item in words)
            {
                var wd = item.Split('=');
                Console.WriteLine("{0}:{1}", ToJapanese(wd[0]),wd[1]);
            }

            
        }
        static string ToJapanese(string key)
        {
            switch (key)
            {
                case "Novelist":
                    return "作家 ";
                case "BestWork":
                    return "代表作 ";
                case "Born":
                    return "誕生年 ";
                default:
                    return "       ";
            }
        }
    }
}
