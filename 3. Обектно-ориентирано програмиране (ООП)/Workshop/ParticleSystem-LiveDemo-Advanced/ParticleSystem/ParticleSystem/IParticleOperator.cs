using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public interface IParticleOperator
    {
        IEnumerable<Particle> OperateOn(Particle p);

        void TickEnded();
    }
}
