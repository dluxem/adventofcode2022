using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

internal class Part2
{
    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");

        var computer = new CrtComputer();

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            computer.Exececute(line);

        }

        int counter = 0;
        foreach (var item in computer.Results)
        {
            if (item.Key % 40 == 0)
            {
                Console.WriteLine();
            }
            if (item.Value) { 
                Console.Write("#");
            }
            else
            {
                Console.Write(' ');
            }
            //Console.WriteLine("Clock: {0} // Value: {1}", item.Key, item.Value);
        }


    }
}

