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
        const int maxX = 99;
        const int maxY = 99;
        var inputFile = File.OpenText("input.txt");
        int x = 0;
        int y = 0;
        Tree[,] forest = new Tree[maxX,maxY];



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

        // North
        for (int northX = 0; northX < maxX; northX++)
        {
            var northMax = -1;
            for (int northY = 0; northY < maxY; northY++)
            {
                Tree tree = forest[northX, northY];
                if (tree.Height > northMax) {
                    tree.Visible = true; 
                    northMax = tree.Height; 
                }
            }
        }

        // south
        for (int southX = 0; southX < maxX; southX++)
        {
            var southMax = -1;
            for (int southY = maxY-1; southY >=0; southY--)
            {
                Tree tree = forest[southX, southY];
                if (tree.Height > southMax) {
                    tree.Visible = true; 
                    southMax = tree.Height;
                }
            }
        }

        // west
        for (int westY = 0; westY < maxY; westY++)
        {
            var westMax = -1;
            for (int westX = 0; westX < maxX; westX++)
            {
                Tree tree = forest[westX, westY];
                if (tree.Height > westMax)
                {
                    tree.Visible = true;
                    westMax = tree.Height;
                }
            }
        }

        // east
        for (int eastY = 0; eastY < maxY; eastY++)
        {
            var eastMax = -1;
            for (int eastX = maxX - 1; eastX >= 0; eastX--)
            {
                Tree tree = forest[eastX, eastY];
                if (tree.Height > eastMax)
                {
                    tree.Visible = true;
                    eastMax = tree.Height;
                }
            }
        }

        int countVisible = Flatten<Tree>(forest).Count(forest => forest.Visible == true);

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

public class Tree
{
    public int Height = 0;
    public bool Visible = false;
    public int ScenicScore { get; set; } = 1;
    public Tree(int height)
    {
        Height = height;
    }
    public override string ToString()
    {
        return String.Format("Height: {0}, Visible: {1}, ScenicScore: {2}", Height, Visible, ScenicScore);
    }

    public void AddToScenic(int x)
    {
        ScenicScore = ScenicScore * x;
    }

}
