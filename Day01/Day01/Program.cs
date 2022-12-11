using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01;

class Program
{
    static void Main(string[] args)
    {
        List<int> elfs = new List<int>();

        try
        {
            var inputFile = File.OpenText(args[0]);
            int calarieCounter = 0;

            while (!inputFile.EndOfStream)
            {
                var line = inputFile.ReadLine();
                if (line is null || line.Trim() == "")
                {
                    if (calarieCounter != 0)
                    {
                        elfs.Add(calarieCounter);
                        calarieCounter = 0;
                    }
                }
                else
                {
                    calarieCounter += int.Parse(line);
                }
            }
        }
        catch (Exception)
        {

            Console.WriteLine("Error opening file \"{0}\"", String.Join(" ", args));
            Environment.Exit(1);
        }

        if (elfs.Count > 0)
        {
            //Console.WriteLine(elfs.Max());

            // max 3
            var result = elfs.OrderByDescending(e => e)
                  .Take(3);

            Console.WriteLine(
                result.Sum()
                ); 
        }
    }
}
