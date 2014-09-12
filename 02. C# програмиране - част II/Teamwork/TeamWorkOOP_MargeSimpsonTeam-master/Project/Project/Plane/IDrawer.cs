using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plane
{
    public interface IDrawer
    {
        void EnqueueForDrawing(GameObject gameObject);
        void DrawAll();
        void Clear();
    }
}
