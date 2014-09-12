using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParticleSystem
{
    public class Engine
    {
        private IParticleOperator particleOperator;

        private List<Particle> particles;

        private IRenderer renderer;

		private int WaitMs { get; set; }

        public Engine(IRenderer renderer, IParticleOperator particleOperator, List<Particle> particles = null, int waitMs=1000)
        {
            this.renderer = renderer;
            this.particleOperator = particleOperator;

            if (particles != null)
            {
                this.particles = particles;
            }
            else
            {
                this.particles = new List<Particle>();
            }

			this.WaitMs = waitMs;
        }

        public void AddParticle(Particle p)
        {
            this.particles.Add(p);
        }

        public void Run()
        {
            while (true)
            {
				var producedParticles = new List<Particle>();

                foreach (var particle in this.particles)
                {
                    var currentParticles=particleOperator.OperateOn(particle);
					producedParticles.AddRange(currentParticles);
                }
				
				particleOperator.TickEnded();
				this.particles.AddRange(producedParticles);

				this.particles.RemoveAll(p => p.Exists == false);

                foreach (var particle in this.particles)
                {
                    renderer.EnqueueForRendering(particle);
                }


                renderer.RenderAll();

				Thread.Sleep(this.WaitMs);

                renderer.ClearQueue();
            }
        }
    }
}
