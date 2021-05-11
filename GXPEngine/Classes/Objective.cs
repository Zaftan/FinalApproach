﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Managers;
using GXPEngine.Physics;

class Objective : PhysicsRectangle
{
    //Level2 lvl2 = new Level2();
    AnimationSprite rocket;
    SceneManager _sceneManager;
    Timer deadTimer;
    string dest;

    public Objective(int width, int height, int x, int y, string destination) : base(width, height, x, y)
    {
        trigger = true;
        //SetColor(System.Drawing.Color.Green);
        dest = destination;

        rocket = ((Level2)game.Currentscene).rocket;
    }

    public override void Update()
    {
        base.Update();

        if (deadTimer != null)
        {
            rocket.Animate();
            if (rocket.y >= 100)
            {
                rocket.y--;
            }

            if(rocket.currentFrame >= 11)
            {
                rocket.SetCycle(13, 18);
            }

            if (rocket.y <= 100)
            {
                LateRemove();
                game.SceneManager.GotoNextscene();
            }
        }
    }

    public override void Collide(PhysicsObject other)
    {
        if (other is Quokka)
        {
            ((Ball)other).Die();

            if (deadTimer == null)
            {
                deadTimer = new Timer(0.1f);
                
                AddChild(deadTimer);
            }
        }
    }
}
