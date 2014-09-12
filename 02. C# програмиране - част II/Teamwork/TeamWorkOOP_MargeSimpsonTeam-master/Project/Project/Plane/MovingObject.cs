using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plane
{
    public class MovingObject : GameObject
    {
        private int colSpeed; //only moves left-right

        public MovingObject()
        {
        }

        public MovingObject(Coord topLeft, char[,] image, ObjectTypes objectType, int colSpeed)
            : base(topLeft, image, objectType)
        {
            this.colSpeed = colSpeed;
            this.Alive = true;
        }

        public override void Update()
        {
            if (this.Alive)
            {
                this.Move();
            }

        }

        private void Move()
        {
            this.TopLeft.Col += colSpeed;
        }

    }
}
