using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace aoc;

public class KnottedRope
{
    public Coordinates[] Knots { get; set; }
    public HashSet<Coordinates> TailHistory { get; set; }

    public KnottedRope() 
    {
        Knots = new Coordinates[10]
        {
                    new Coordinates(), new Coordinates(), new Coordinates(),
                    new Coordinates(), new Coordinates(), new Coordinates(),
                    new Coordinates(), new Coordinates(),
                    new Coordinates(), new Coordinates()
        };
        TailHistory = new HashSet<Coordinates>
        {
            Knots[Knots.Length - 1]
        };

    }

    public void MoveHead(string direction, int distance)
    {
        for (int i = 0; i < distance; i++)
        {
            Console.WriteLine(Knots[0]);
            Console.WriteLine("Move " + direction);
            Knots[0] = Move(Knots[0], direction);
            for (int k = 1; k < Knots.Length; k++)
            {
                Console.WriteLine("Index: {2} -- Leader: {0} -- Follow: {1}", Knots[k-1], Knots[k], k);
                CalculateNextKnotMove(k);
            }
            
            
        }
    }

    private void CalculateNextKnotMove(int followerIndex)
    {
        // default to no move
        string direction = "";
        Coordinates leader = Knots[followerIndex - 1];
        Coordinates follower = Knots[followerIndex];

        // Are we close? Both X and Y diff < 2
        if ((Math.Abs(leader.X - follower.X) <2) && (Math.Abs(leader.Y - follower.Y) < 2)) {
            return;
        }

        //Move Up
        if (follower.Y < leader.Y) { direction = "U"; }

        //Move Down
        if (follower.Y > leader.Y) { direction = "D"; }

        //Move Left
        if (follower.X > leader.X) { direction += "L";}

        //Move Right
        if (follower.X < leader.X) { direction += "R"; }

        MoveFollower(direction, followerIndex);

    }


    private void MoveFollower(string direction, int followerIndex)
    {
        Coordinates follower = Knots[followerIndex];

        // Change tail coordinates
        Knots[followerIndex] = Move(follower, direction);

        // Log new location
        // only if last follower
        if (followerIndex == 9)
        {
            if (TailHistory.Add(Knots[followerIndex]))
            {
                Console.WriteLine("New Tail Location {0}", Knots[followerIndex].ToString());
            }
            else
            {
                Console.WriteLine("EXISTING Tail Location {0}", Knots[followerIndex].ToString());
            }
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
