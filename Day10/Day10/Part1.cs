using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

internal class Part1
{
    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");

        var computer = new Computer();

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            computer.Exececute(line);

        }

        int counter = 0;
        foreach (var item in computer.Results)
        {
            Console.WriteLine("Clock: {0} // Value: {1}", item.Key, item.Value);
            counter += (item.Key * item.Value);
        }

        Console.WriteLine(counter);
        

    }

}

