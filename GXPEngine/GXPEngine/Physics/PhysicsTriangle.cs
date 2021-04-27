using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;

namespace GXPEngine.Physics
{
    public class PhysicsTriangle : PhysicsPolygon
    {
        public PhysicsTriangle(int pWidth, int pHeight, Vector2 pPosition) :
            base(
            new List<Vector2>()
            {
                new Vector2(- pWidth / 2, - pHeight / 2),
                new Vector2(pWidth / 2, pHeight / 2),
                new Vector2(0, 0),
            },
            pPosition)
        {
        }

        protected override void Draw()
        {
            base.Draw();
        }
    }
}
