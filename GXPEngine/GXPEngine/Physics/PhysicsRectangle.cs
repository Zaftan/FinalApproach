using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;

namespace GXPEngine.Physics
{
    public class PhysicsRectangle : PhysicsPolygon
    {
        /*        public PhysicsRectangle(int pWidth, int pHeight, Vector2 pPosition) : base(pWidth, pHeight, pPosition)
                {
                    _points = new List<PhysicsCircle>()
                    {
                        new PhysicsCircle(1, new Vector2(position.x - width / 2, position.y - height / 2)),
                        new PhysicsCircle(1, new Vector2(position.x + width / 2, position.y - height / 2)),
                        new PhysicsCircle(1, new Vector2(position.x + width / 2, position.y + height / 2)),
                        new PhysicsCircle(1, new Vector2(position.x - width / 2, position.y + height / 2))
                    };
                }*/

        public PhysicsRectangle(int pWidth, int pHeight, Vector2 pPosition) : base(pWidth, pHeight, pPosition)
        {
            _points = createPoints(new List<Vector2>()
            {
                new Vector2(position.x - width / 2, position.y - height / 2),
                new Vector2(position.x + width / 2, position.y - height / 2),
                new Vector2(position.x + width / 2, position.y + height / 2),
                new Vector2(position.x - width / 2, position.y + height / 2)
            });

            //vecRotation.angleDeg = 45f;
        }

        protected override void Draw()
        {
            base.Draw();
            //draw.Rect(0, 0, width * 2, height * 2);
        }
    }
}
