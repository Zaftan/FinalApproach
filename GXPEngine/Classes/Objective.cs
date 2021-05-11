using System;
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
    bool played = false;

    public Objective(int width, int height, int x, int y, string destination) : base(width, height, x, y)
    {
        trigger = true;
        //SetColor(System.Drawing.Color.Green);
        dest = destination;

        rocket = ((Level)game.Currentscene).rocket;
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
                if (played == false)
                {
                    new Sound(Settings.ASSET_PATH + "SFX/Rocket.wav").Play(false, 0, 10, 0);
                    played = true;
                }
            }

            if (rocket.currentFrame >= 11)
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
            ((Quokka)other).LateDestroy();

            if (deadTimer == null)
            {
                deadTimer = new Timer(0.1f);
                
                AddChild(deadTimer);
                new Sound(Settings.ASSET_PATH + "SFX/LevelWin.wav").Play(false, 0, 10, 0);
            }
        }
    }
}
