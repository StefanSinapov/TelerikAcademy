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

        private int waitMs;

        public Engine(IRenderer renderer, IParticleOperator particleOperator, List<Particle> particles = null, int waitMs = 1000)
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

            this.waitMs = waitMs;
        }

        public void AddParticle(Particle p)
        {
            this.particles.Add(p);
        }

        public void Run()
        {
            while (true)
            {   //Tick //Frame
                var producedParticles = new List<Particle>();

                foreach (var particle in this.particles)
                {
                    var currentProduced = particleOperator.OperateOn(particle);
                    producedParticles.AddRange(currentProduced);
                }

                particleOperator.TickEnded();

                this.particles.AddRange(producedParticles);

                this.particles.RemoveAll((p) => !p.Exists);

                foreach (var particle in this.particles)
                {
                    renderer.EnqueueForRendering(particle);
                }

                renderer.RenderAll();
                renderer.ClearQueue();

                Thread.Sleep(this.waitMs);
            }
        }
    }
}
