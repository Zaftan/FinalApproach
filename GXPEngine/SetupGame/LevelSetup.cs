using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;
using System.Drawing;

public class EngineTest : Level
{

    PhysicsPolygon rectangle;

    public EngineTest() : base("EngineTest"/*, name + "Background.png"*/)
    {
        gravity = new Vector2(0, 2000f);
    }

    public override void onLoad()
    {
        base.onLoad();

        PhysicsLine line = new PhysicsLine(new Vector2(0, 200), new Vector2(200, 500));
        line.SetColor(Color.Green);
        AddChild(line);

        PhysicsLine line2 = new PhysicsLine(new Vector2(500, 500), new Vector2(800, 200));
        line2.SetColor(Color.Green);
        AddChild(line2);

        PhysicsLine line3 = new PhysicsLine(new Vector2(200, 500), new Vector2(500, 500));
        line3.SetColor(Color.Green);
        AddChild(line3);

        rectangle = new PhysicsRectangle(200, 40, new Vector2(200, 200));
        rectangle.vecRotation.angleDeg = 45f;

        rectangle.SetColor(Color.Red);
        AddChild(new RotatingThing(200, 40, 200, 200));
        AddChild(new Mattress(50, 50, 100, 100));
        AddChild(new Spring(50, 50, 200, 100));
    }

    public override void Update()
    {
        rectangle.vecRotation.RotateDegrees(1f);

        if (Input.GetKeyUp(Key.S))
        {
            Ball ball = new Ball(10);
            ball.position = new Vector2(width/2, 0);

            AddChild(ball);
        }

        if (Input.GetMouseButtonUp(2))
        {
            PhysicsCircle circle = new PhysicsCircle(10, new Vector2(Input.mouseX, Input.mouseY));
            circle.SetColor(Color.Red);

            AddChild(circle);
        }
    }
}

public class Level : Scene 
{
    protected Camera mainCam;
    public Player player;
    public Vector2 gravity;

    protected MyGame myGame;

    public Level(string name) : base(name/*, name + "Background.png"*/)
    {
        myGame = (MyGame)game;
    }

    public override void Update()
    {
    }

    public override void onLoad()
    {
        base.onLoad();

        player = new Player();
        AddChild(player);
    }

    public override void onLeave()
    {
        base.onLeave();
    }
}
