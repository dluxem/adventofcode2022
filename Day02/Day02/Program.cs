// See https://aka.ms/new-console-template for more information

/*

A Y
B X
C Z

shape
-----
Rock = 1
Paper = 2
Scissors = 3

outcome
----
Lost = 0
Draw = 3
Win = 6

Score = shape + outcome

A = Rock
B = Paper
C = Scissors

X = Rock
Y = Paper
Z = Scissors
 
 */


List<int> elfs = new List<int>();
int score = 0;

try
{
    var inputFile = File.OpenText(args[0]);

    while (!inputFile.EndOfStream)
    {
        var line = inputFile.ReadLine();
        if (line is null || line.Trim() == "")
        {
            continue;
        }
        else
        {
            var parts = line.Split(' ');
            var scoreShape = 0;
            var scoreWin = 0;
            switch (parts[1])
            {
                case "X": // Lose
                    scoreWin = 0;
                    if (parts[0] == "A") { scoreShape = 3; } // A Rock, Z scissors 3
                    if (parts[0] == "B") { scoreShape = 1; } // B paper, X rock 1
                    if (parts[0] == "C") { scoreShape = 2; } // C scissors, Y paper 2
                    break;
                case "Y": // Draw
                    scoreWin = 3;
                    if (parts[0] == "A") { scoreShape = 1; } 
                    if (parts[0] == "B") { scoreShape = 2; }
                    if (parts[0] == "C") { scoreShape = 3; }
                    break;
                case "Z": // Win
                    scoreWin = 6;
                    if (parts[0] == "A") { scoreShape = 2; } // A rock,  paper 2
                    if (parts[0] == "B") { scoreShape = 3; } // B paper,  scissors 3
                    if (parts[0] == "C") { scoreShape = 1; } // C scissors,  rock 1
                    break;
                    
                default:
                    Console.WriteLine("ERROR READING");
                    break;
            }

            score += (scoreShape + scoreWin);
            
        }
    }
}
catch (Exception)
{

    Console.WriteLine("Error opening file \"{0}\"", String.Join(" ", args));
    Environment.Exit(1);
}

Console.WriteLine(score);


