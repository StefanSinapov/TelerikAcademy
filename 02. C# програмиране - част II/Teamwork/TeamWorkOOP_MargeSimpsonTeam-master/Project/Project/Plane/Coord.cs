
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    public class Coord
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Coord()
        {
        }

        public Coord(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static Coord operator +(Coord first, Coord second)
        {
            Coord result = new Coord(first.Row + second.Row, first.Col + second.Col);
            return result;
        }

        public static Coord operator -(Coord first, Coord second)
        {
            Coord result = new Coord(first.Row - second.Row, first.Col - second.Col);
            return result;
        }

        public static bool operator ==(Coord leftCoords, Coord rightCoords)
        {
            bool result = false;

            if (leftCoords.Equals(null) && rightCoords.Equals(null))
            {
                if (leftCoords.Col == rightCoords.Col && leftCoords.Row == rightCoords.Row)
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool operator !=(Coord leftCoords, Coord rightCoords)
        {
            bool result = true;

            if (leftCoords.Equals(null) && rightCoords.Equals(null))
            {
                if (leftCoords.Col == rightCoords.Col && leftCoords.Row == rightCoords.Row)
                {
                    result = false;
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 2;
        }

    }
}
