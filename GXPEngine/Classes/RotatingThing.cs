using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

class RotatingThing : Placable
{
    private PhysicsRectangle rotatingThing;

    public RotatingThing(int pWidth, int pHeight, int pX, int pY) : base(new Vector2(pX, pY))
    {
        width = pWidth;
        height = pHeight;

        x = pX;
        y = pY;

        rotatingThing = new PhysicsRectangle(pWidth, pHeight, new Vector2(pX, pY));
        rotatingThing.bouncyness = 1.5f;
        rotatingThing.SetColor(System.Drawing.Color.Red);
        PhysicsObjects.Add(rotatingThing);
    }

    protected override void Run()
    {
        rotatingThing.vecRotation.RotateDegrees(0.5f);
    }
}
