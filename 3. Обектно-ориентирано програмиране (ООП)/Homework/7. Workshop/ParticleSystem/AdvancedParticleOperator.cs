using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        List<ParticleAttractor> attractors = new List<ParticleAttractor>();
        List<Particle> particles = new List<Particle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var attractorCandidate = p as ParticleAttractor;
            if (attractorCandidate == null)
            {
                this.particles.Add(p);
            }
            else
            {
                this.attractors.Add(attractorCandidate);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.attractors)
            {
                foreach (var particle in this.particles)
                {
                    var currAcceleration = GetAccelerationFromParticleToAttractor(attractor, particle);

                    particle.Accelerate(currAcceleration);
                }
            }

            this.attractors.Clear();
            this.particles.Clear();
            base.TickEnded();
        }

        private static MatrixCoords GetAccelerationFromParticleToAttractor(ParticleAttractor attractor, Particle particle)
        {
            var currParticleToAttractorVector = attractor.Position - particle.Position;

            int pToAttrRow = currParticleToAttractorVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(attractor, pToAttrRow);

            int pToAttrCol = currParticleToAttractorVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(attractor, pToAttrCol);

            var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);
            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.Power)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * attractor.Power;
            }
            return pToAttrCoord;
        }
    }
}
