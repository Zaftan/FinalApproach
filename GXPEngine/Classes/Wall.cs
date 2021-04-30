using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

class Wall : Placable
{
    private PhysicsRectangle body;

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

        body = new PhysicsRectangle(pWidth, pHeight, new Vector2(0, 0));
        body.SetColor(System.Drawing.Color.Red);
        PhysicsObjects.Add(body);
    }

    protected override void Run()
    {
    }
}
