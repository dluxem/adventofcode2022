using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc
{
    internal class Part1
    {
        public static void Run()
        {
            /* 
             *         
                        [G]         [D]     [Q]    
                [P]     [T]         [L] [M] [Z]    
                [Z] [Z] [C]         [Z] [G] [W]    
                [M] [B] [F]         [P] [C] [H] [N]
                [T] [S] [R]     [H] [W] [R] [L] [W]
                [R] [T] [Q] [Z] [R] [S] [Z] [F] [P]
                [C] [N] [H] [R] [N] [H] [D] [J] [Q]
                [N] [D] [M] [G] [Z] [F] [W] [S] [S]
                 1   2   3   4   5   6   7   8   9 
            */

            // move 7 from 6 to 8
            // move 5 from 2 to 6

            var inputFile = File.OpenText("input.txt");

            int counter = 0;

            List<Stack<char>> stacks = new List<Stack<char>>();
            stacks.Add(new Stack<char>(new char[] { 'N', 'C', 'R', 'T', 'M', 'Z', 'P' }));
            stacks.Add(new Stack<char>(new char[] { 'D','N','T','S','B','Z'  }));
            stacks.Add(new Stack<char>(new char[] { 'M','H','Q','R','F','C','T','G' }));
            stacks.Add(new Stack<char>(new char[] { 'G','R','Z'}));
            stacks.Add(new Stack<char>(new char[] { 'Z', 'N', 'R', 'H' }));
            stacks.Add(new Stack<char>(new char[] { 'F','H','S','W','P','Z','L','D'}));
            stacks.Add(new Stack<char>(new char[] { 'W','D','Z','R','C','G','M'}));
            stacks.Add(new Stack<char>(new char[] { 'S','J','F','L','H','W','Z','Q'}));
            stacks.Add(new Stack<char>(new char[] { 'S','Q','P','W','N'}));

            //stacks[1].Push(stacks[0].Pop());

            while (!inputFile.EndOfStream)
            {                
                var line = inputFile.ReadLine();
                if (line is null || line.Trim() == "") { continue; }
                else
                {
                    // move 7 from 6 to 8
                    // 0    1 2    3 4  5
                    string[] parts = line.Split(' ');
                    var sourceStack = Int32.Parse(parts[3]) - 1;
                    var destStack = Int32.Parse(parts[5]) - 1;
                    var count = Int32.Parse(parts[1]);
                    Move(ref stacks, sourceStack, destStack, count);

                }

            }

            Console.WriteLine();
            foreach (Stack<char> item in stacks)
            {
                Console.Write(item.Peek());
            }

        }

        private static void Move(ref List<Stack<char>> stacks, int sourceStack, int destStack, int numToMove)
        {
            for (int i = 0; i < numToMove; i++)
            {
                stacks[destStack].Push(stacks[sourceStack].Pop());

            }

        }


    }
}
