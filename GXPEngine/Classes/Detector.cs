using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;

class Detector : PhysicsCircle
{
    public Detector(int pRadius) : base(pRadius, new GXPEngine.Core.Vector2(0, 0))
    {
        SetColor(System.Drawing.Color.Blue);
        velocity.SetXY(0, 0.01f);
        //effectedByGravity = true;
    }

    public override void Collide(PhysicsObject other)
    {
        Console.WriteLine("Whaa");
        SetColor(System.Drawing.Color.Red);
    }

    public void Update()
    {
        UpdateScreenPosition();
        position.SetXY(Input.mouseX, Input.mouseY);

        if (Input.GetMouseButtonDown(0))
        {
            SetColor(System.Drawing.Color.Blue);
        }
    }
}

