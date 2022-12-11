using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace aoc;

public class Rope
{
    public Coordinates Head { get; set; }
    public Coordinates Tail { get; set;  }

    public HashSet<Coordinates> TailHistory { get; set; }

    public Rope() 
    { 
        Head = new Coordinates();
        Tail = new Coordinates();

        TailHistory = new HashSet<Coordinates>
        {
            Tail
        };

    }

    public void MoveHead(string direction, int distance)
    {
        for (int i = 0; i < distance; i++)
        {
            Console.WriteLine("Tail: {0} -- Head: {1} -- Move {2}", Tail, Head, direction);
            Head = Move(Head, direction);
            
            CalculateTailMove();
        }
    }

    private void CalculateTailMove()
    {
        // default to no move
        string direction = "";

        // Are we close? Both X and Y diff < 2
        if ((Math.Abs(Head.X - Tail.X) <2) && (Math.Abs(Head.Y - Tail.Y) < 2)) {
            return;
        }

        //Move Up
        if (Tail.Y < Head.Y) { direction = "U"; }

        //Move Down
        if (Tail.Y > Head.Y) { direction = "D"; }

        //Move Left
        if (Tail.X > Head.X) { direction += "L";}

        //Move Right
        if (Tail.X < Head.X) { direction += "R"; }

        MoveTail(direction);

    }


    private void MoveTail(string direction)
    {
        // Change tail coordinates
        Tail = Move(Tail, direction);

        // Log new location
        if (TailHistory.Add(Tail))
        {
            Console.WriteLine("New Tail Location {0}", Tail.ToString());
        }
        else
        {
            Console.WriteLine("EXISTING Tail Location {0}", Tail.ToString());
        }
    }

    private Coordinates Move(Coordinates current, string? direction)
    {
        var destination = new Coordinates();
        destination.X = current.X;
        destination.Y = current.Y;
        switch (direction)
        {
            case "R":
                destination.X++; 
                break;
            case "D": 
                destination.Y--;
                break;
            case "L":
                destination.X--;
                break;
            case "U":
                destination.Y++;
                break;
            case "UR":
                destination.X++;
                destination.Y++;
                break;
            case "DR":
                destination.X++;
                destination.Y--;
                break;
            case "DL":
                destination.X--;
                destination.Y--;
                break;
            case "UL":
                destination.X--;
                destination.Y++;
                break;
            default:
                break;
        }
        return destination;

    }
    
}
