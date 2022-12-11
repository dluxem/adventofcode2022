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
        const int maxX = 99;
        const int maxY = 99;
        var inputFile = File.OpenText("input.txt");
        int x = 0;
        int y = 0;
        Tree[,] forest = new Tree[maxX, maxY];



        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            foreach (char c in line.ToCharArray())
            {
                //Console.WriteLine(c);

                forest[x, y] = new Tree((int)Char.GetNumericValue(c));
                //Console.WriteLine(forest[x,y].ToString());
                x++;
            }
            x = 0;
            y++;
        }

        for (int treeX = 0; treeX < maxX; treeX++)
        {
            for (int treeY = 0; treeY< maxY; treeY++)
            {
                // Evaluate Scenic

                // Go North
                var northMax = forest[treeX, treeY].Height;
                var northCount = 0;
                if (treeY > 0)
                {
                    for (int northY = treeY - 1; northY >= 0; northY--)
                    {
                        northCount++;
                        Tree tree = forest[treeX, northY];
                        if (tree.Height >= northMax)
                        {
                            break;
                        }
                    }
                    forest[treeX, treeY].AddToScenic(northCount);
                }
                else { northCount = 1; }


                // Go south
                var southMax = forest[treeX, treeY].Height;
                var southCount = 0;
                if (treeY < maxY - 1)
                {
                    for (int southY = treeY +1; southY < maxY; southY++)
                    {
                        southCount++;
                        Tree tree = forest[treeX, southY];
                        if (tree.Height >= southMax)
                        {
                            break;
                        }
                    }
                    forest[treeX, treeY].AddToScenic(southCount);
                }
                else { southCount = 1; }
                

                // west
                // Go west
                var westMax = forest[treeX, treeY].Height;
                var westCount = 0;
                if (treeX > 0)
                {
                    for (int westX = treeX - 1; westX >= 0; westX--)
                    {
                        Tree tree = forest[westX, treeY];
                        westCount++;
                        if (tree.Height >= westMax)
                        {
                            break;
                            
                        }
                    }
                    forest[treeX, treeY].AddToScenic(westCount);
                }
                else
                {  westCount = 1; }
                

                // Go east
                var eastMax = forest[treeX, treeY].Height;
                var eastCount = 0;
                if (treeX < maxX - 1)
                {
                    for (int eastX = treeX + 1; eastX < maxX; eastX++)
                    {
                        eastCount++;
                        Tree tree = forest[eastX, treeY];
                        if (tree.Height >= eastMax)
                        {
                            break;
                        }
                    }
                    forest[treeX, treeY].AddToScenic(eastCount);
                }
                else { eastCount = 1; }

                // Add together
                forest[treeX, treeY].ScenicScore = northCount * southCount * eastCount * westCount;



            }

        }


        int countVisible = Flatten<Tree>(forest).Max(x => x.ScenicScore);

        Console.WriteLine(countVisible);

    }

    public static IEnumerable<T> Flatten<T>(T[,] map)
    {
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                yield return map[row, col];
            }
        }
    }

}
