using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class DyingParticle : Particle
    {
        private uint lifespan;

        public DyingParticle(MatrixCoords position, MatrixCoords speed, uint lifespan = uint.MaxValue) :
            base(position, speed)
        {
            this.lifespan = lifespan;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { (char)3 } };
        }

        public override bool Exists
        {
            get
            {
                return this.lifespan > 0;
            }
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.Exists)
            {
                this.lifespan--;
            }

            return base.Update();
        }
    }
}
