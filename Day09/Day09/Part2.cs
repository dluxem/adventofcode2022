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

        var rope = new KnottedRope();

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            var parts = line.Split(' ');
            rope.MoveHead(parts[0], Int32.Parse(parts[1]));
        }

        foreach (var coord in rope.TailHistory)
        {
            Console.WriteLine(coord.ToString());
        }
        Console.WriteLine("Number Visited: {0}", rope.TailHistory.Count());


    }
}

