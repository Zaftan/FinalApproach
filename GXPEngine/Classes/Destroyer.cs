using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Physics;

class Destroyer : GameObject
{
    AnimationSprite body;

    Timer laserDelay;
    bool on;
    Laser laser;
    int width;
    int height;

    private void On()
    {
        on = true;

        laser = new Laser(width, height - (width*2), (int)x, height / 2 + (int)y);
        laser.position.RotateAroundDegrees(rotation, new GXPEngine.Core.Vector2(x, y));
        laser.vecRotation.RotateDegrees(rotation);
        game.Currentscene.AddChild(laser);
        body.SetFrame(34);
        laserDelay.Start();
    }
    private void Off()
    {
        on = false;
        laser.LateRemove();
        laserDelay.Start();
        body.SetFrame(0);
    }

    public Destroyer(int x, int y, float pRotation = 0) : base()
    {
        body = new AnimationSprite(Settings.ASSET_PATH + "Art/LaserSpriteSheet.png", 5, 7, 35, false, false);

        this.x = x;
        this.y = y;
        width = body.width;
        height = body.height;
        rotation = pRotation;

        body.SetXY(-width/2, 0);
        AddChild(body);

        laserDelay = new Timer(4f);
        AddChild(laserDelay);

        PhysicsRectangle side = new PhysicsRectangle(width, width, x, y + width/2);
        side.position.RotateAroundDegrees(rotation, new GXPEngine.Core.Vector2(x, y));
        //side.SetColor(System.Drawing.Color.Gray);
        game.Currentscene.AddChild(side);

        side = new PhysicsRectangle(width, width, x, height + y - width / 2);
        side.position.RotateAroundDegrees(rotation, new GXPEngine.Core.Vector2(x, y));
        //side.SetColor(System.Drawing.Color.Gray);
        game.Currentscene.AddChild(side);

        On();
    }

    void Update()
    {
        if (laserDelay.done)
        {
            if (on)
            {
                Off();
            }
            else if (!on)
            {
                On();
            }
        }
    }
}

