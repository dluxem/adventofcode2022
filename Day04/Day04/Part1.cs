using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    internal class Part1
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

                // elf2 in elf1
                if (Int32.Parse(elf1parts[0]) <= Int32.Parse(elf2parts[0]) && (Int32.Parse(elf1parts[1]) >= Int32.Parse(elf2parts[1])))
                {
                    counter++;
                    Console.WriteLine("ELF1 contains ELF2");
                    continue; // skip next check
                }

                // elf1 in elf2
                if (Int32.Parse(elf2parts[0]) <= Int32.Parse(elf1parts[0]) && (Int32.Parse(elf2parts[1]) >= Int32.Parse(elf1parts[1])))
                {
                    counter++;
                    Console.WriteLine("ELF2 contains ELF1");
                }
            }
            Console.WriteLine("Count: {0}", counter);
        }


    }
}
