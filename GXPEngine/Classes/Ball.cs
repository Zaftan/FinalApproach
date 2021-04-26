using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine.Core;

class Ball : PhysicsCircle
{
    public Ball(int pRadius) : base(pRadius, new GXPEngine.Core.Vector2(0, 0))
    {
        SetColor(System.Drawing.Color.Blue);
        effectedByGravity = true;
    }

    public override void Collide(PhysicsObject other)
    {
        base.Collide(other);

        if (other is PhysicsLine)
        {
            velocity.Reflect(((PhysicsLine)other).lineVector.Normal(), 0f);
            //Console.WriteLine(Colliding((PhysicsLine)other));
        }
        else if (other is PhysicsCircle)
        {
            velocity.Reflect(Vector2.DirectionBetween(position, other.position).Normalized(), 0f);
        }
    }

    public void Update()
    {
        Step();
    }
}

