using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;

namespace GXPEngine.Physics
{
    public class PhysicsCircle : PhysicsObject
    {
        public int radius
        {
            get{ return _radius;}
        }
        private int _radius;

        public PhysicsCircle(int pRadius, Vector2 pPosition) : base(pRadius * 2 + 1, pRadius * 2 + 1, pPosition)
        {
            _radius = pRadius;
        }

        public override bool Colliding(PhysicsLine lineSegment)
        {
            Vector2 _lineToBall = position - lineSegment.start;
            float ballDistance = _lineToBall.Dot(lineSegment.lineVector.Normal());

            if (ballDistance < radius)
            {
                Vector2 middle = (lineSegment.start + lineSegment.end) * 0.5f;
                Vector2 middleToBall = position - middle;

                if (middleToBall.length < lineSegment.lineVector.length / 2)
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Colliding(PhysicsCircle other)
        {
            Vector2 Difference = position - other.position;
            float distance = Difference.length;
            float minDistance = other.radius + radius;

            if (minDistance > distance)
            {
                return true;
            }

            return false;
        }

        public override void Collide(PhysicsObject other)
        {
            //base.Collide(other);

            if (other is PhysicsLine)
            {
                Vector2 _lineVector = ((PhysicsLine)other).lineVector;
                Vector2 _lineToBall = position - ((PhysicsLine)other).start;
                float ballDistance = _lineToBall.Dot(_lineVector.Normal());
                position = position + (-ballDistance + radius) * _lineVector.Normal();
                return;
            }
            if (other is PhysicsCircle)
            {
                Vector2 Difference = position - other.position;
                float distance = Difference.length;

                Vector2 normal = Difference.Normalized();
                float overlap = ((PhysicsCircle)other).radius + radius - distance;

                position = position + normal * overlap;
                return;
            }
        }

        protected override void Draw()
        {
            draw.Ellipse(radius, radius, radius * 2, radius * 2);
        }
    }
}
