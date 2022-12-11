using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

internal class Computer
{
    private int ClockCounter;
    private int[] registers;
    public Dictionary<int, int> Results;

    public Computer() 
    {
        ClockCounter = 1;
        registers = new int[1]
        {
            1
        };
        Results = new Dictionary<int, int>();
        Results.Add(20, 0);
        Results.Add(60, 0);
        Results.Add(100, 0);
        Results.Add(140, 0);
        Results.Add(180, 0);
        Results.Add(220, 0);
    }

    public void Exececute(string command)
    {
        if (command is null) { return; }
        if (command.Trim().Length == 0) { return; }

        var opCodes = command.Split(' ');
        int clockChange = 0;
        if (opCodes[0] == "noop")
        {
            clockChange= 1;
            CheckRegister(0, ClockCounter, clockChange);
        }
        if (opCodes[0] == "addx")
        {
            clockChange= 2;
            CheckRegister(0, ClockCounter, clockChange);
            // write register after change
            registers[0] += Int32.Parse(opCodes[1]);
        }
        ClockCounter += clockChange;
    }

    private void CheckRegister(int registerNumber, int previousClock, int clockIncrement)
    {
        foreach (var resultClock in Results.Keys)
        {
            if (resultClock >= previousClock & resultClock < (previousClock+ clockIncrement))
            {
                Results[resultClock] = registers[registerNumber];
            }
        }
    }
}
