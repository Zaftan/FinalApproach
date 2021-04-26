using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine.Core;

namespace GXPEngine.Physics
{
    public class PhysicsPolygon : PhysicsObject
    {
        public List<PhysicsObject> points
        {
            get
            {
                List<PhysicsObject> outP = _points;

                foreach (PhysicsCircle point in outP)
                {
                    point.position.RotateAroundDegrees(vecRotation.angleDeg, position);
                }

                return outP;
            }
        }
        public List<PhysicsObject> lines
        {
            get
            {
                List <PhysicsObject> outP = new List<PhysicsObject> ();
                List<PhysicsObject> temp = points;

                for (int i = 0; i < temp.Count - 1; i++)
                {
                    outP.Add(new PhysicsLine(temp[i].position, temp[i + 1].position));
                }

                outP.Add(new PhysicsLine(temp[temp.Count - 1].position, temp[0].position));

                return outP;
            }
        }
        protected List<PhysicsObject> _points;

        public PhysicsPolygon(List<Vector2> pPoints, Vector2 pPosition) : base(calculateWidth(pPoints), calculateHeight(pPoints), pPosition)
        {
            _points = createPoints(pPoints);
        }

        protected PhysicsPolygon(int pWidth, int pHeight, Vector2 pPosition) : base(pWidth, pHeight, pPosition)
        {
        }

        private static int calculateWidth(List<Vector2> pPoints)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (Vector2 point in pPoints)
            {
                int pointX = (int)point.x;

                if (pointX < min) min = pointX;
                if (pointX > max) max = pointX;
            }

            return max - min;
        }

        private static int calculateHeight(List<Vector2> pPoints)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (Vector2 point in pPoints)
            {
                int pointY = (int)point.y;

                if (pointY < min) min = pointY;
                if (pointY > max) max = pointY;
            }

            return max - min;
        }

        protected List<PhysicsObject> createPoints ( List<Vector2> positions)
        {
            List<PhysicsObject> outP = new List<PhysicsObject>();

            foreach (Vector2 point in positions)
            {
                outP.Add(new PhysicsCircle(1, point));
            }

            return outP;
        }

        public override bool Colliding(PhysicsLine lineSegment)
        {
            throw new NotImplementedException();
        }

        public override bool Colliding(PhysicsCircle circle)
        {
            throw new NotImplementedException();
        }

        public override void Collide(PhysicsObject other)
        {
        }

        protected override void Draw()
        {
            foreach (PhysicsLine _line in lines)
            {
                _line.SetColor(Color.Blue);
                Console.WriteLine(_line.lineVector.angleDeg);
                game.Currentscene.AddChild(_line);
            }
        }
    }
}