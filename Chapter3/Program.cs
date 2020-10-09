using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program
    {
        //デリゲートの宣言(int型の引数を受け取ってbool値を返すメソッド)
        public delegate bool Judgement(int value);

        static void Main(string[] args)
        {
            var list = new List<string>
            {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong kong",
            };

            list.ConvertAll(s => s.ToUpper()).ForEach(s => Console.WriteLine(s));

            //list.ForEach(s => Console.WriteLine(s));

            //var name = list.FindAll(s => s.Length <= 5);

            //foreach (var n in name)
            //{
            //    Console.WriteLine(n);
            //}

        }
    }
}
