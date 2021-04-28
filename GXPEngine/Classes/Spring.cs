using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;

public class Spring : Placable
{
    private PhysicsRectangle matress;

    public Spring(int pWidth, int pHeight, int pX, int pY) : base(new Vector2(pX, pY))
    {
        width = pWidth;
        height = pHeight;

        SetXY(pX, pY);

        matress = new PhysicsRectangle(pWidth, pHeight, new Vector2(pX, pY));

        matress.bouncyness = -100;
        matress.SetColor(System.Drawing.Color.Beige);
        PhysicsObjects.Add(matress);
    }

    protected override void Run()
    {
    }
}
