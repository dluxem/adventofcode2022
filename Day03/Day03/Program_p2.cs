// See https://aka.ms/new-console-template for more information
Console.WriteLine("Part 2");

var inputFile = File.OpenText("input.txt");

int total = 0;
int elfCount = 1;
string[] ruckSacks = new string[3];
int foundCount = 0;
bool found = false;

while (!inputFile.EndOfStream)
{


    var line = inputFile.ReadLine();
    if (line is null || line.Trim() == "")
    {
        Console.WriteLine("DEAD LINE");
        continue;
    }
    else {

        // add to set
        ruckSacks[elfCount-1] = line;
        elfCount++;
    }

    if (elfCount == 4)
    {
        // analyse set
        Console.WriteLine(ruckSacks[0]);
        Console.WriteLine(ruckSacks[1]);
        Console.WriteLine(ruckSacks[2]);
        foreach (char c in ruckSacks[0].Distinct().ToArray())
        {
            if (ruckSacks[1].Contains(c, StringComparison.Ordinal))
            {
                if (ruckSacks[2].Contains(c, StringComparison.Ordinal))
                {
                    //found it
                    Console.WriteLine(c);

                    int charValue;

                    // update case
                    if (c == Char.ToUpper(c))
                    {
                        charValue = (int)c - 38;
                    }
                    else
                    {
                        //lower case
                        charValue = (int)c - 96;
                    }
                    Console.WriteLine(charValue);
                    total += charValue;
                    foundCount++;
                    Console.WriteLine("Total: {0}", total);
                    Console.WriteLine("Found Count: {0}", foundCount);
                    found = true;

                }
            }
        }


        // new set
        elfCount = 1;
        if (!found)
        {
            Console.WriteLine("ERROR, nothing found");
            Environment.Exit(1);
        }
        found = false;
        Console.WriteLine();
    }

}

Console.WriteLine("Total: {0}", total);
Console.WriteLine("Found Count: {0}", foundCount);