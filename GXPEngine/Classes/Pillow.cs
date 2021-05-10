using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;

public class Pillow : Placable
{
    public Pillow() : base(new Vector2(0, 0))
    {
        Sprite body = new Sprite(Settings.ASSET_PATH + "Art/pillow.png", false, false);
        width = body.width;
        height = body.height;
        body.SetOrigin(body.width / 2, body.height / 2);

        AddChild(body);

        PhysicsRectangle matress = new PhysicsRectangle(width - 5, height - 5, new Vector2(0, 0));

        matress.bouncyness = -100;
        //matress.SetColor(System.Drawing.Color.Green);
        PhysicsObjects.Add(matress);
    }

    protected override void Run()
    {
    }
}
