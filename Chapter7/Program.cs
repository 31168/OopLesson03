using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            var Dict = new Dictionary<string, List<string>>();

            Console.WriteLine("辞書表示プログラム");

            while (true)
            {
                Console.WriteLine("\n１．登録　２．内容を表示　３．終了");
                int num =int.Parse(Console.ReadLine());;
                //while (true)
                //{
                //    num = int.Parse(Console.ReadLine());
                //    if (num >= 1 && num >= 3)
                //        break;
                //}

                if (num == 1)
                {
                    Console.Write("KEYを入力：");
                    string key = Console.ReadLine();

                    Console.Write("VALUEを入力：");
                    var value = Console.ReadLine();
                    if (Dict.ContainsKey(key))
                    {
                        Dict[key].Add(value);
                    }
                    else
                    {
                        Dict[key] = new List<string> { value };
                    }

                    Console.WriteLine("登録しました！");
                }
                else if(num == 2)
                {

                    foreach (var item in Dict)
                    {
                        foreach(var term in item.Value)
                            Console.WriteLine("{0}：{1}", item.Key, term);
                    }
                }
                else
                {
                    break;
                }
                
            }
        }
    }
}
