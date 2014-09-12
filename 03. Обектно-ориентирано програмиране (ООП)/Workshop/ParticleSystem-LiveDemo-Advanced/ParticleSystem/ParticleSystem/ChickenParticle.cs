using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
	public class ChickenParticle : ChaoticParticle
	{
		// Fields
		public readonly char[,] ChickenParticleImage = { { (char)12 } };
		private readonly MatrixCoords Stop = new MatrixCoords(0, 0);
		private const double ChanceToStop = 0.04;
		private bool isStopped = false;

		//Constructor
		public ChickenParticle(MatrixCoords position, MatrixCoords speed, uint speedRange, Random randomGenerator)
			: base(position, speed, speedRange, randomGenerator)
		{

		}

		//Methods
		public override char[,] GetImage()
		{
			return this.ChickenParticleImage;
		}

		protected override void Move()
		{
			//this.Accelerate(new MatrixCoords(this.Speed.Row * (-1), this.Speed.Col * (-1)));
			base.Move();
		}
		public override IEnumerable<Particle> Update()
		{

			if(RandomGenerator.Next(0,100)<ChanceToStop*100 || isStopped)
			{
				var lastKnownSpeed = this.Speed;
				this.Accelerate(new MatrixCoords(this.Speed.Row * (-1), this.Speed.Col * (-1)));
				this.isStopped = true;
			}
			if(this.isStopped)
			{
				this.isStopped = false;
				var baseProduced = base.Update();

				List<Particle> newProduced = new List<Particle>()
                    {
                        new ChickenParticle(this.Position,this.Speed,(uint)this.MaxSpeedCoord,this.RandomGenerator)
                    };

				newProduced.AddRange(baseProduced);

				return newProduced;
			}


			return base.Update();
		}
	}
}
