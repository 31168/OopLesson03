using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Enshu7
{
    class Program
    {
        static void Main(string[] args)
        {
            //7-1
            #region
            var tex = "Cozy lummox gives smart squid who asks for job pen";
            var alfaDict = new SortedDictionary<char, int>();
            
            for(char i = 'a'; i<='z'; i++)
                alfaDict.Add(i, 0);

            var text = tex.Replace(" ","").ToCharArray();


            for(int i=0; i<text.Length; i++)
            {
                if ('A' <= text[i] && text[i] <= 'Z')
                    text[i] = char.ToLower(text[i]);

                int sum = alfaDict[text[i]];
                alfaDict[text[i]] = sum + 1;
            }

           
            foreach(var i in alfaDict)
                Console.WriteLine("{0} = {1}", i.Key, i.Value);
            #endregion //7-1

            //7-2
            #region

            var Abbreviations = new Dictionary<string, string>
            {

            };

            #endregion
        }
    }
}
