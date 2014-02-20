using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
	public class DyingParticle : Particle
	{
		public uint Lifespan { get; private set; }

		public DyingParticle(MatrixCoords position, MatrixCoords speed, uint lifespan = uint.MaxValue)
			: base(position, speed)
		{
			this.Lifespan = lifespan;
		}

		public override char[,] GetImage()
		{
			return new char[,] { { (char)1 } };
		}
		public override bool Exists
		{
			get
			{
				return this.Lifespan>0;
			}
		}

		public override IEnumerable<Particle> Update()
		{
			if(this.Exists)
			{
				this.Lifespan--;
			}
			return base.Update();
		}
	}
}
