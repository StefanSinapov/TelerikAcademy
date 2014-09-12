using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plane
{
    public class Plane : GameObject
    {        
        public Plane(Coord topLeft,char[,] image, ObjectTypes objectType)
            :base(topLeft,image, objectType)
        {
            this.Alive = true;
        }

        public override void Move(Coord direction)
        {
            this.TopLeft += direction;
        }

    }
}
