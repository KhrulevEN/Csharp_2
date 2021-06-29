using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App02
{
    /*
    2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
    а) для целых чисел;
    б) *для НЕ обобщенной коллекции;
    в) *используя Linq.
    */


    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("а) List<int>");
            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 5, 7, 12, 7, 3, 11, 12, 7, 7, 1, 5 });
            var numberDict1 = new Dictionary<int, int>();
            for (int i=0; i<list.Count; i++)
            {
                if (!numberDict1.ContainsKey(list[i]))
                    numberDict1.Add(list[i], 1);
                else
                {
                    int n = numberDict1[list[i]];
                    n++;
                    numberDict1[list[i]] = n;
   
                }
            }
            foreach (KeyValuePair<int, int> keyValue in numberDict1)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.ReadLine();

            Console.WriteLine("б) Queue<int>");
            Queue<int> Q1 = new Queue<int>(new[] { 1, 5, 7, 12, 7, 3, 11, 12, 7, 7, 1, 5 });
            var numberDict2 = new Dictionary<int, int>();
            while (Q1.Count>0)
            {
                int numb = Q1.Dequeue();
                if (!numberDict2.ContainsKey(numb))
                    numberDict2.Add(numb, 1);
                else
                {
                    int n = numberDict2[numb];
                    n++;
                    numberDict2[numb] = n;

                }
            }
            foreach (KeyValuePair<int, int> keyValue in numberDict1)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.ReadLine();

            Console.WriteLine("в) LINQ");
            ILookup<int, int> lookup =
                list
                .ToLookup(i => i, i => i);
            foreach (IGrouping<int, int> listGroup in lookup)
            {
                Console.WriteLine($"{listGroup.Key} - {listGroup.Count()}");
            }

            Console.ReadLine();
        }
    }
}
