using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
	class Program
	{
		const int rows = 30;
		const int cols = 30;
		static readonly Random randomGenerator = new Random();

		static void Main(string[] args)
		{
			var renderer = new ConsoleRenderer(rows, cols);
			var particalOperator = new ParticleUpdater();

			var engine = new Engine(renderer, particalOperator, null, 300);
			GenerateInitialParticles(engine);

			engine.Run();
		}

		private static void GenerateInitialParticles(Engine engine)
		{
			engine.AddParticle(
						new Particle(
							new MatrixCoords(5, 5),
							new MatrixCoords(1, 1))
							);

			engine.AddParticle(
				new DyingParticle(
					new MatrixCoords(5, 5),
					new MatrixCoords(0, 1),
					10)
					);

			var emitter = new ParticleEmitter(new MatrixCoords(5, 5), new MatrixCoords(0, 0), randomGenerator,
				100,
				2,
				(emitterParameter) =>
				{
					MatrixCoords particlePosition = emitterParameter.Position;

					int particalRowSpeen = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
					int particalColSpeen = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
					MatrixCoords particleSpeed = new MatrixCoords(particalRowSpeen, particalColSpeen);

					Particle generated = null;


					int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);
					switch (particleTypeIndex)
					{
						case 0: generated = new Particle(particlePosition, particleSpeed);
							break;
						case 1:
							int lifespan = emitterParameter.RandomGenerator.Next(15);
							generated = new DyingParticle(particlePosition, particleSpeed, (uint)lifespan);
							break;
						default:
							throw new Exception("No such particle");
					}
					return generated;
				}
				);
			engine.AddParticle(emitter);
		}
	}
}
