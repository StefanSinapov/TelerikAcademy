using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleUpdater : IParticleOperator
    {
        public virtual IEnumerable<Particle> OperateOn(Particle p)
        {
            return p.Update();
        }

        public virtual void TickEnded()
        {
        }
    }
}
