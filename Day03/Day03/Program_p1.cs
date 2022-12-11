class Part1 {
    static void Run()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        var inputFile = File.OpenText("input.txt");

        var itemList = new List<char>();
        int total = 0;

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            if (line is null || line.Trim() == "")
            {
                continue;
            }
            else
            {
                var first = line.Substring(0, (line.Length / 2));
                var last = line.Substring(line.Length / 2, (line.Length / 2));
                Console.WriteLine("Orig: {0} // First: {1} // Last {2}", line, first, last);
                foreach (char c in first)
                {
                    if (last.Contains(c, StringComparison.Ordinal))
                    {
                        itemList.Add(c);
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
                        break;
                    }

                }

            }


        }
        Console.WriteLine(total);
    }
}
