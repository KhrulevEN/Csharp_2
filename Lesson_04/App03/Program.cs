using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App03
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            { {"four",4 }, {"two",2 }, { "one",1 }, {"three",3 } };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.ReadLine();

            var d1 = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d1)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.ReadLine();
        }
    }
}
