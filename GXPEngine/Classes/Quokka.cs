using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;

class Quokka : PhysicsCircle
{
    Timer deadTimer;
    Sprite body;

    public Quokka(int pRadius) : base(pRadius, new GXPEngine.Core.Vector2(0, 0))
    {
        //SetColor(System.Drawing.Color.Blue);
        effectedByGravity = true;
        bouncyness = 0.65f;
        
        body = new Sprite(Settings.ASSET_PATH + "Art/Quokka.png", false);
        body.SetOrigin(radius, radius);
        AddChild(body);
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
        if (velocity.length > 1500f)
        {
             velocity.length = 1500f;
        }

        //Console.WriteLine(velocity.length);
        velocity -= ((Level)game.Currentscene).resistance * velocity;
        base.applyVelocity();
    }

    public override void Update()
    {
        body.rotation = velocity.angleDeg + 90;

        if (deadTimer != null)
        {
            if (deadTimer.done)
                LateRemove();
        }

        base.Update();

        if (Input.GetKeyDown(Key.S))
        {
            Die();
        }
    }

    public void Die()
    {
        if (deadTimer == null)
        {
            deadTimer = new Timer(0.05f);
            AddChild(deadTimer);
            LateRemove();
            parent.recieveMessage("dead");
        }

        SetColor(System.Drawing.Color.Red);
    }
}

