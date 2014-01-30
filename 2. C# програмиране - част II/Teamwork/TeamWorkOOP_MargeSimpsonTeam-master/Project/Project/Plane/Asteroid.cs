using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plane
{
    class Asteroid : MovingObject
    {
        public Asteroid()
            : base()
        {
        }

        public Asteroid(Coord center, char[,] image, ObjectTypes objType, int speed)
            :base(center, image, objType, speed)
        {
            this.Alive = true;
        }
        
        


    }
}
