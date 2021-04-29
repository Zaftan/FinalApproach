using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;

public class Spring : Placable
{
    private PhysicsRectangle spring;
    private PhysicsLine right;
    private PhysicsLine bottem;
    private PhysicsLine left;

    public Spring(int pWidth, int pHeight, int pX, int pY) : base(new Vector2(pX, pY))
    {
        width = pWidth;
        height = pHeight;

        SetXY(pX, pY);

        left = new PhysicsLine(-width / 2, -height / 2, -width / 2, height);
        left.SetColor(System.Drawing.Color.Green);
        PhysicsObjects.Add(left);

        bottem = new PhysicsLine(- width / 2, height, width / 2, height);
        bottem.SetColor(System.Drawing.Color.Green);
        PhysicsObjects.Add(bottem);

        right = new PhysicsLine(width / 2, height, width / 2, -height / 2);
        right.SetColor(System.Drawing.Color.Green);
        PhysicsObjects.Add(right);

        spring = new PhysicsRectangle(pWidth - 12, pHeight, new Vector2(-2, 0));
        spring.bouncyness = 1f;
        spring.SetColor(System.Drawing.Color.Red);
        PhysicsObjects.Add(spring);
    }

    protected override void Run()
    {
    }
}
