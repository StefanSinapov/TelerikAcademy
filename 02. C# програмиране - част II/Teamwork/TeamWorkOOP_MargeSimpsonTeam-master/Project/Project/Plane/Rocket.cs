using System;
using System.Linq;

namespace Plane
{
    public class Rocket : MovingObject
    {
        public Rocket(Coord topLeft, char[,] image, ObjectTypes objectType, int colSpeed)
            : base(topLeft, image, objectType, colSpeed)
        {

        }

    }
}
