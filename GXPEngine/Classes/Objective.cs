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
    SceneManager _sceneManager;
    string dest;

    public Objective(int width, int height, int x, int y, string destination) : base(width, height, x, y)
    {
        trigger = true;
        SetColor(System.Drawing.Color.Green);
        dest = destination;
    }

    public override void Collide(PhysicsObject other)
    {
        if (other is Ball)
        {
            //((Ball)other).Die();
            game.SceneManager.GotoNextscene();
        }
    }
}