using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

class Wall : Placable
{
    private PhysicsRectangle collider;

    public Wall(int pWidth, int pHeight, int pX, int pY) : base(new Vector2(pX, pY))
    {
        if (width < height)
        {
            width = height = pWidth;
        }
        else
        {
            width = height = pHeight;
        }

        x = pX;
        y = pY;

        collider = new PhysicsRectangle(pWidth, pHeight, new Vector2(0, 0));
        collider.SetColor(System.Drawing.Color.Red);
        PhysicsObjects.Add(collider);
    }

    protected override void Run()
    {
    }
}
