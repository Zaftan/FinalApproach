using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;

class Ball : PhysicsCircle
{
    Timer deadTimer;

    public Ball(int pRadius) : base(pRadius, new GXPEngine.Core.Vector2(0, 0))
    {
        SetColor(System.Drawing.Color.Blue);
        effectedByGravity = true;
        bouncyness = 0.5f;
    }

    public override bool moving
    {
        get { return true; }
    }

    public override void Collide(PhysicsObject other)
    {
        base.Collide(other);

        float reflectStrength = other.bouncyness + bouncyness;
        if (reflectStrength < 0) reflectStrength = 0;

        if (other is PhysicsLine)
        {
            velocity.Reflect(((PhysicsLine)other).lineVector.Normal(), reflectStrength);
        }
        else if (other is PhysicsCircle)
        {
            velocity.Reflect(Vector2.DirectionBetween(position, other.position).Normalized(), reflectStrength);
        }
    }

    protected override void applyVelocity()
    {
        velocity -= 0.005f * velocity;
        base.applyVelocity();
    }

    public override void Update()
    {
        if (deadTimer != null)
        {

            if (deadTimer.done)
                LateRemove();
        }

        base.Update();

        if (Input.GetKeyDown(Key.S))
        {
            Destroy();
        }
    }

    public void Die()
    {
        if (deadTimer == null)
        {
            deadTimer = new Timer(0.05f);
            AddChild(deadTimer);
        }

        SetColor(System.Drawing.Color.Red);
    }
}

