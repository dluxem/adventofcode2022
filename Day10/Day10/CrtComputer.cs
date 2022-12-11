using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

internal class CrtComputer
{
    private int ClockCounter;
    private int[] registers;
    public Dictionary<int, bool> Results;

    public CrtComputer() 
    {
        ClockCounter = 0;
        registers = new int[1]
        {
            1
        };
        Results = new Dictionary<int, bool>();
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
        
        for (int i = previousClock; i < previousClock+clockIncrement; i++)
        {
            int crtIndex = i % 40;
            if (Math.Abs(registers[registerNumber] - crtIndex) < 2) // + or - 1
            {
                Results[i] = true;
            }
            else
            {
                Results[i] = false;
            }
        }
    }
}
