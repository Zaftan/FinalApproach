using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Physics;

class Destroyer : GameObject
{
    Timer laserDelay;
    bool on;
    Laser laser;
    int width;
    int height;

    private void On()
    {
        on = true;

        laser = new Laser(width, height, (int)x, height / 2 + (int)y);
        laser.position.RotateAroundDegrees(rotation, new GXPEngine.Core.Vector2(x, y));
        laser.vecRotation.RotateDegrees(rotation);
        game.Currentscene.AddChild(laser);

        laserDelay.Start();
    }
    private void Off()
    {
        on = false;
        laser.LateRemove();
        laserDelay.Start();
    }

    public Destroyer(int width, int height, int x, int y, float pRotation = 0) : base()
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.rotation = pRotation;

        laserDelay = new Timer(4f);
        AddChild(laserDelay);

        PhysicsRectangle side = new PhysicsRectangle(width, width, x, y);
        side.position.RotateAroundDegrees(rotation, new GXPEngine.Core.Vector2(x, y));
        side.SetColor(System.Drawing.Color.Gray);
        game.Currentscene.AddChild(side);

        side = new PhysicsRectangle(width, width, x, height + y);
        side.position.RotateAroundDegrees(rotation, new GXPEngine.Core.Vector2(x, y));
        side.SetColor(System.Drawing.Color.Gray);
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

