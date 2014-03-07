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
		
		const int Rows = 30;
		const int Cols = 50;

		static readonly Random RandomGenerator = new Random();

		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.Unicode;

			var renderer = new ConsoleRenderer(Rows, Cols);

			var particleOperator = new AdvancedParticleOperator();

			var engine =
				new Engine(renderer, particleOperator, null, 300);

			//GenerateInitialData(engine);

			//Homework
			AddChaoticParticle(engine);

			AddChickenParticles(engine);

			AddReppellerParticle(engine);

			engine.Run();
		}

		private static void AddReppellerParticle(Engine engine)
		{
			var reppeller = new ParticleRepeller(new MatrixCoords(20, 9),
												new MatrixCoords(0, 0),
												2);

			engine.AddParticle(reppeller);
		}

		private static void AddChickenParticles(Engine engine)
		{
			var chickenParticleOne = new ChickenParticle(
											new MatrixCoords(8, 8),
											 new MatrixCoords(1, 1),
											 1,
											 RandomGenerator);
			var chickenParticleTwo = new ChickenParticle(
											new MatrixCoords(8, 8),
											 new MatrixCoords(0, 0),
											 2,
											 RandomGenerator);
			engine.AddParticle(chickenParticleOne);
			engine.AddParticle(chickenParticleTwo);

		}


		private static void AddChaoticParticle(Engine engine)
		{
			var chaoticParticles = new List<ChaoticParticle>{
			 new ChaoticParticle(new MatrixCoords(8, 8),
									new MatrixCoords(0, 0),
									3,
									RandomGenerator),
			 new ChaoticParticle(new MatrixCoords(8, 8),
									new MatrixCoords(0, 0),
									2,
									RandomGenerator),
			 new ChaoticParticle(new MatrixCoords(8, 8),
									new MatrixCoords(0, 0),
									1,
									RandomGenerator)
			};
			foreach (var item in chaoticParticles)
			{
				engine.AddParticle(item);
			}
		}

		private static void GenerateInitialData(Engine engine)
		{
			engine.AddParticle(
				new Particle(
					new MatrixCoords(0, 8),
					new MatrixCoords(-1, 0))
				);

			engine.AddParticle(
				new DyingParticle(
					new MatrixCoords(20, 5),
					new MatrixCoords(-1, 1),
					12)
				);

			var emitterPosition = new MatrixCoords(29, 0);
			var emitterSpeed = new MatrixCoords(0, 0);
			var emitter = new ParticleEmitter(emitterPosition, emitterSpeed,
				RandomGenerator,
				5,
				2,
				GenerateRandomParticle
				);

			engine.AddParticle(emitter);

			var attractorPosition = new MatrixCoords(10, 3);
			var attractor = new ParticleAttractor(
				attractorPosition,
				new MatrixCoords(0, 0),
				1);

			var attractorPosition2 = new MatrixCoords(10, 13);
			var attractor2 = new ParticleAttractor(
				attractorPosition2,
				new MatrixCoords(0, 0),
				2);

			engine.AddParticle(attractor);
			engine.AddParticle(attractor2);
		}

		static Particle GenerateRandomParticle(ParticleEmitter emitterParameter)
		{
			MatrixCoords particlePos = emitterParameter.Position;

			int particleRowSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
			int particleColSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);

			MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

			Particle generated = null;

			int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);
			switch (particleTypeIndex)
			{
				case 0: generated = new Particle(particlePos, particleSpeed); break;
				case 1:
					uint lifespan = (uint)emitterParameter.RandomGenerator.Next(8);
					generated = new DyingParticle(particlePos, particleSpeed, lifespan);
					break;
				default:
					throw new Exception("No such particle for this particleTypeIndex");
			}
			return generated;
		}
	}
}
