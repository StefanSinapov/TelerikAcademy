using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
	public class ParticleEmitter : Particle
	{
		
		private uint maxEmittetPerTickCount;
		private Func<ParticleEmitter, Particle> randomParticleGeneratorMethod;

		public ParticleEmitter(MatrixCoords position, MatrixCoords speed, Random randomGenerator, uint maxEmittedPerTickCount, uint maxAbsSpeedCoord, Func<ParticleEmitter, Particle> randomParticleGeneratorMethod)
			: base(position, speed)
			
		{
			this.maxEmittetPerTickCount = maxEmittedPerTickCount;
			this.MaxSpeedCoord = (int)maxAbsSpeedCoord;
			this.MinSpeedCoord = -(int)maxAbsSpeedCoord;
			this.RandomGenerator = randomGenerator;
			this.randomParticleGeneratorMethod = randomParticleGeneratorMethod;
		}

		//Properties
		public Random RandomGenerator { get; private set; }
		public int MaxSpeedCoord { get; private set; }
		public int MinSpeedCoord { get; private set; }

		public override IEnumerable<Particle> Update()
		{
			var baseProduced = base.Update();
			List<Particle> produced = new List<Particle>();
			int emittedCount = this.RandomGenerator.Next((int)this.maxEmittetPerTickCount + 1);

			for (int i = 0; i < emittedCount; i++)
			{
				Particle p = GetRandomParticle();
				produced.Add(p);
			}
			return baseProduced;
		}

		private Particle GetRandomParticle()
		{
			//MatrixCoords particlePosition = this.Position;

			//int particalRowSpeen = this.RandomGenerator.Next(this.minSpeedCoord, this.maxSpeedCoord + 1);
			//int particalColSpeen = this.RandomGenerator.Next(this.minSpeedCoord, this.maxSpeedCoord + 1);

			Particle result = this.randomParticleGeneratorMethod(this);

			return result;
		}
	}
}
