using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

class Wall : Placable
{
    private PhysicsRectangle rect;

    public Wall(int pWidth, int pHeight, int pX, int pY) : base(new Vector2(pX, pY))
    {
        //build(length);
        width = pWidth;
        height = pHeight;

        x = pX;
        y = pY;

        rect = new PhysicsRectangle(width, height, new Vector2(0, 0));
        rect.SetColor(System.Drawing.Color.Red);
        PhysicsObjects.Add(rect);
    }

    void build(int length)
    {
        Sprite body;

        for (int i = 0; i < length;)
        {
            body = new Sprite(Settings.ASSET_PATH + "Art/metal_wall.png");
            //body.SetOrigin(body.width/2, body.height/2);

            body.x = i;

            height = body.height;

            i += body.width;
            AddChild(body);

            width = i;
        }
    }

    protected override void Run()
    {
    }
}
