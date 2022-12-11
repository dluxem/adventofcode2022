using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

public class Coordinates : IEquatable<Coordinates>
{
    public int X = 0;
    public int Y = 0;

    public bool Equals(Coordinates? other)
    {
        if (other is null) {
            return false; 
        }
        
        return (this.X == other.X && this.Y == other.Y);

    }

    public override string ToString()
    {
        return String.Format("X: {0} // Y: {1}", X, Y);
    }

    public override int GetHashCode()
    {
        return String.Format("{0}{1}", this.X, this.Y).GetHashCode();
    }
}
