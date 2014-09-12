using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{


	public class ChaoticParticle:Particle
	{
		public Random RandomGenerator { get; private set; }
        public int MinSpeedCoord { get; private set; }
        public int MaxSpeedCoord { get; private set; }
		public ChaoticParticle(MatrixCoords position,MatrixCoords speed,int speedRange)
			:base(position,speed)
		{

		}
	}
}
