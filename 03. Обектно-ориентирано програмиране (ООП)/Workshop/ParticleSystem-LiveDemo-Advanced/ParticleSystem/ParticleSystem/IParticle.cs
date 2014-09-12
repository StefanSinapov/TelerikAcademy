using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public interface IParticle
    {
        MatrixCoords Position
        {
            get;
        }
    
        IEnumerable<IParticle> Update();

        bool Exists
        {
            get;
        }
    }
}
