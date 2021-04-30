using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine;

public class Spring : Placable
{
    private PhysicsRectangle spring;
    private PhysicsRectangle right;
    private PhysicsRectangle left;

    private AnimationSprite body;

    public Spring(int pX, int pY) : base(new GXPEngine.Core.Vector2(pX, pY))
    {
        body = new AnimationSprite(Settings.ASSET_PATH + "Art/spring.png", 1, 1, 1, false, false);
        width = body.width/2;
        height = body.height/2;
        body.SetOrigin(body.width /2, body.height /2);
        body.scale = 0.5f;

        AddChild(body);

        SetXY(pX, pY);

        left = new PhysicsRectangle(2, height, -width / 2, 0);
        //left.SetColor(System.Drawing.Color.Green);
        left.vecRotation.angleDeg = 180f;
        PhysicsObjects.Add(left);

        /*      bottem = new PhysicsLine(- width / 2, height, width / 2, height);
                bottem.SetColor(System.Drawing.Color.Green);
                PhysicsObjects.Add(bottem);*/

        right = new PhysicsRectangle(2, height, width / 2, 0);
        //right.SetColor(System.Drawing.Color.Pink);
        PhysicsObjects.Add(right);

        spring = new PhysicsRectangle(width - 4, height, 0, 0);
        spring.bouncyness = 0.6f;
        //spring.SetColor(System.Drawing.Color.Red);
        PhysicsObjects.Add(spring);
    }

    protected override void Run()
    {
    }
}
