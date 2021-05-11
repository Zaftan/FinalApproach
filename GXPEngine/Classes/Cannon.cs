﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

public class Cannon : Sprite
{
    AnimationSprite body;

    public Cannon(int pX, int pY) : base(Settings.ASSET_PATH + "Art/Cannonbacksprite.png", true, false)
    {
        x = pX;
        y = pY;

        SetOrigin(width / 2, height / 2);

        body = new AnimationSprite(Settings.ASSET_PATH + "Art/LaucherSheet2.png", 10, 4, 38, false, false);
        body.SetOrigin(body.width/2, body.height/2);
        body.SetCycle(0, 37, 1);

        PhysicsRectangle rect = new PhysicsRectangle(body.width, body.height, new Vector2(x, y));
        //rect.SetColor(System.Drawing.Color.Red);
        game.Currentscene.AddChild(rect);
        AddChildAt(body, 1000);
    }

    void Update()
    {

        if (body.currentFrame > 35)
        {
            Quokka ball = new Quokka(15);
            ball.position = new Vector2(x, y);
            ball.velocity = new Vector2(0, 1500f);
            game.Currentscene.AddChildAt(ball, 100);

            ((Level)game.Currentscene).mainCam.Shake();

            body.SetFrame(0);
        }
        else if (body.currentFrame > 0)
        {
            body.Animate();
        }

        if (Input.GetKeyUp(Key.S))
        {
            body.SetFrame(1);
        }
    }
}
