using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    internal class Part2
    {
        public static void Run()
        {
            var inputFile = File.OpenText("input.txt");

            int counter = 0;

            while (!inputFile.EndOfStream)
            {
                var line = inputFile.ReadLine();
                if (line == null) { continue; }

                var parts = line.Split(",");
                var elf1parts = parts[0].Split("-");
                var elf2parts = parts[1].Split("-");

                Console.WriteLine("ELF1: {0} // ELF2: {1}", parts[0], parts[1]);

                
                var a = Int32.Parse(elf1parts[0]);
                var b = Int32.Parse(elf1parts[1]);
                var x = Int32.Parse(elf2parts[0]);
                var y = Int32.Parse(elf2parts[1]);

                if (a<=x && b>=x)
                {
                    counter++;
                    Console.WriteLine("Overlap, elf1 smaller");
                    continue; // skip next check
                }

               if (x<=a & y>=a)
                { 
                    counter++;
                    Console.WriteLine("Overlap, ELF2 smaller");
                }
            }
            Console.WriteLine("Count: {0}", counter);
        }
    }
}
