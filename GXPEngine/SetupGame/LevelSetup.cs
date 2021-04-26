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
    public EngineTest() : base("EngineTest"/*, name + "Background.png"*/)
    {
        gravity = new Vector2(0, 0.981f);
    }

    public override void onLoad()
    {
        base.onLoad();

        PhysicsLine line = new PhysicsLine(new Vector2(400, 700), new Vector2(700, 1000));
        line.SetColor(Color.Green);
        AddChild(line);

        PhysicsLine line2 = new PhysicsLine(new Vector2(1000, 1000), new Vector2(1300, 700));
        line2.SetColor(Color.Green);
        AddChild(line2);

        PhysicsLine line3 = new PhysicsLine(new Vector2(700, 1000), new Vector2(1000, 1000));
        line3.SetColor(Color.Green);
        AddChild(line3);

        PhysicsRectangle rectangle = new PhysicsRectangle(50, 100, new Vector2(width /2 , height/2));
        rectangle.vecRotation.angleDeg = 90f;

        rectangle.SetColor(Color.Red);
        AddChild(rectangle);
    }

    public override void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ball ball = new Ball(10);
            ball.position = new Vector2(Input.mouseX, Input.mouseY);

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

    private MyGame myGame;

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
