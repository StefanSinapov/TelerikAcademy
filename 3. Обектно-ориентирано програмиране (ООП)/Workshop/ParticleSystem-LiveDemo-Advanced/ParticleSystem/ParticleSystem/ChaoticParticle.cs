using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{


	public class ChaoticParticle:Particle
	{
		private readonly char[,] ChaoticParticleImage=new char[,] { { '©' } };
		
		public ChaoticParticle(MatrixCoords position,MatrixCoords speed,uint maxSpeedRange, Random randomGenerator)
			:base(position,speed)
		{
			this.MinSpeedCoord = -(int)maxSpeedRange;
			this.MaxSpeedCoord = (int)maxSpeedRange;
			this.RandomGenerator = randomGenerator;
		}

		public Random RandomGenerator { get; private set; }
		public int MinSpeedCoord { get; private set; }
		public int MaxSpeedCoord { get; private set; }

		protected override void Move()
		{
			base.Accelerate(this.GetRandomSpeed());
			base.Move();
		}

		public override char[,] GetImage()
		{
			return ChaoticParticleImage;
		}

		private MatrixCoords GetRandomSpeed()
		{
			var col = this.RandomGenerator.Next(MinSpeedCoord, MaxSpeedCoord + 1);
			var row = this.RandomGenerator.Next(MinSpeedCoord, MaxSpeedCoord + 1);
			return new MatrixCoords(row, col);
		}
	}
}
