using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine;

public class Spring : Placable
{
    AnimationSprite body;
    PhysicsRectangle spring;

    public Spring() : base(new GXPEngine.Core.Vector2(0, 0))
    {
        body = new AnimationSprite(Settings.ASSET_PATH + "Art/spring.png", 6, 2, 12, false, false);
        width = body.width;
        height = body.height;
        body.SetOrigin(body.width / 2, body.height / 2);

        AddChild(body);

        PhysicsRectangle left = new PhysicsRectangle(2, height, -width / 2, 0);
        //left.SetColor(System.Drawing.Color.Green);
        left.vecRotation.angleDeg = 180f;
        PhysicsObjects.Add(left);

        PhysicsRectangle right = new PhysicsRectangle(2, height, width / 2, 0);
        //right.SetColor(System.Drawing.Color.Pink);
        PhysicsObjects.Add(right);

        spring = new PhysicsRectangle(width - 4, height, 0, 0);
        spring.bouncyness = 0.60f;
        //spring.SetColor(System.Drawing.Color.Red);
        PhysicsRectangle spring2 = new PhysicsRectangle(width - 14, height - 10, 0, 0);
        spring2.bouncyness = 0.60f;
        //PhysicsObjects.Add(spring2);
        PhysicsObjects.Add(spring);
    }

    protected override void Run()
    {
    }
}
