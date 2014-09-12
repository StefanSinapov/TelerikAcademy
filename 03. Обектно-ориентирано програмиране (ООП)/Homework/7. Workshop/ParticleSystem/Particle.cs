using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class Particle : IRenderable, IAcceleratable
    {
        public Particle(MatrixCoords position, MatrixCoords speed)
        {
            this.Position = position;
            this.Speed = speed;
        }

        public MatrixCoords Position { get; private set; }

        public virtual IEnumerable<Particle> Update()
        {
            Move();

            return new List<Particle>();
        }

        protected virtual void Move()
        {
            this.Position += this.Speed;
        }

        public MatrixCoords GetTopLeft()
        {
            return this.Position;
        }

        public virtual char[,] GetImage()
        {
            return new char[,] { { '$' } };
        }

        public virtual bool Exists
        {
            get { return true; }
        }

        public MatrixCoords Speed { get; private set; }

        public void Accelerate(MatrixCoords acceleration)
        {
            this.Speed += acceleration;
        }
    }
}