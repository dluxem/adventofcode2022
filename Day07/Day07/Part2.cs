using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc
{
    internal class Part2
    {
        public static void Run()
        {

            var inputFile = File.OpenText("input.txt");
            var workingDir = new ElfDirectory("root", null);

            // Skip firs line
            inputFile.ReadLine();
            bool readNext = true;
            string line = "";
            string nextLine = "";

            while (!inputFile.EndOfStream)
            {
                if (readNext)
                {
                    line = inputFile.ReadLine();
                }
                else
                {
                    line = nextLine;
                }
                if (line is null || line.Trim() == "") { continue; }
                else
                {
                    var lineParts = line.Split(' ');
                    if (lineParts[1] == "cd")
                    {
                        if (lineParts[2] == "..")
                        {
                            workingDir = workingDir.Parent;
                        }
                        else
                        {
                            workingDir = workingDir.subDirs[lineParts[2]];
                        }
                        readNext = true;
                        continue;
                    }
                    if (lineParts[1] == "ls")
                    {
                        // parse ls
                        List<string> lsOutput = new List<string>();
                        bool stopLs = false;
                        while (!stopLs)
                        {
                            var lsLine = inputFile.ReadLine();
                            if (lsLine is null)
                            {
                                // done reading
                                stopLs = true;
                                readNext = false;
                                nextLine = lsLine;
                                ls(lsOutput.ToArray<string>(), ref workingDir);
                                break;
                            }
                            var lsTest = lsLine.Split(' ');
                            if (lsTest[0] == "$")
                            {
                                // done reading
                                stopLs = true;
                                readNext = false;
                                nextLine = lsLine;
                                ls(lsOutput.ToArray<string>(), ref workingDir);
                            }
                            else
                            {
                                // keep reading
                                lsOutput.Add(lsLine);
                            }

                        }

                    }


                }

            }

            while (workingDir.Parent is not null)
            {
                workingDir = workingDir.Parent;
            }

            Console.WriteLine(workingDir.GetTotalSize("/"));

        }

        private static void ls(string[] output, ref ElfDirectory curDir)
        {
            int sizeCounter = 0;
            foreach (var line in output)
            {
                var parts = line.Split(' ');
                if (parts[0] == "dir")
                {
                    curDir.subDirs.Add(parts[1], new ElfDirectory(parts[1], curDir));
                }
                else
                {
                    sizeCounter += Int32.Parse(parts[0]);
                }
            }
            curDir.Size = sizeCounter;
        }

    }

}
