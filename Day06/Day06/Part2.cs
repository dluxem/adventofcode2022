using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc
{
    internal class Part2
    {
        public static void Run()
        {

            var inputFile = File.OpenText("input.txt");
            var line = inputFile.ReadLine();

            Queue<char> codes = new Queue<char>(4);
            int counter = 0;

            foreach (char c in line)
            {
                if (codes.Count == 14) { codes.Dequeue(); }
                codes.Enqueue(c);
                counter++;
                if (codes.Count == 14)
                {
                    if (CheckUnique(codes))
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Counter: {0}", counter);
        }

        private static bool CheckUnique(Queue<char> values)
        {
            var codeList = values.ToArray();
            var val = (codeList.Distinct().Count() == values.Count);
            Console.WriteLine(new string(codeList));
            if (val)
            {
                Console.WriteLine(new string(codeList));
            }
            return val;

        }


    }
}
