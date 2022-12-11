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

        Monkey[] monkies = MonkeyLoader.GetProd();

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("Round " + i);
            for (int m = 0; m < monkies.Length; m++)
            {
                //Console.WriteLine("Monkey " + m + " // Items: " + monkies[m].ToString());
                var thrown = monkies[m].AnalyseItems();                
                foreach (var item in thrown)
                {
                    monkies[item.DestinationMonkey].Items.Enqueue(item.WorryLevel);
                }
            }

            for (int m = 0; m < monkies.Length; m++)
            {
                Console.WriteLine("Monkey " + m + " // Items: " + monkies[m].ToString());
            }
        }

        var top = monkies.OrderByDescending(m => m.AnalysedItems).Take(2).ToArray();
        int monkeybusiness = top[0].AnalysedItems * top[1].AnalysedItems;
        Console.WriteLine("Monkey Business " + monkeybusiness);
        

    }

}

