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

    public EngineTest() : base("level1")
    {
        gravity = new Vector2(0, 2000f);
    }

    public override void onLoad()
    {
        base.onLoad();
        AddChild(new Wall(150, 50, 350, 50));
        AddChild(new Wall(150, 50, 350, 50));
        AddChild(new Wall(150, 50, 350, 50));
        AddChild(new Wall(150, 50, 350, 50));
        AddChild(new Wall(150, 50, 350, 50));
        AddChild(new Wall(150, 50, 350, 50));
        AddChild(new Wall(150, 50, 350, 50));
        AddChild(new Wall(150, 50, 350, 50));

        AddChild(new Spring(550, 50));
        AddChild(new Spring(550, 50));
        AddChild(new Spring(550, 50));
        AddChild(new Spring(550, 50));
        AddChild(new Spring(550, 50));
        AddChild(new Spring(550, 50));
        AddChild(new Spring(550, 50));
        AddChild(new Spring(550, 50));

        AddChild(new Mattress(150, 50, 750, 50));
        AddChild(new Mattress(150, 50, 750, 50));
        AddChild(new Mattress(150, 50, 750, 50));
        AddChild(new Mattress(150, 50, 750, 50));
        AddChild(new Mattress(150, 50, 750, 50));
        AddChild(new Mattress(150, 50, 750, 50));
        AddChild(new Mattress(150, 50, 750, 50));
        AddChild(new Mattress(150, 50, 750, 50));

        AddChild(new MetalWall(3, 215, 550));

        AddChild(new MetalWall(2, 530, 650));

        AddChild(new MetalWall(3, 730, 600));
        AddChild(new MetalWall(2, 730, 600, -90));
        AddChild(new MetalWall(1, 1115, 600, -90));
        AddChild(new MetalWall(2, 1215, 500));

        AddChild(new MetalWall(2, 530, 398, 90));
        AddChild(new MetalWall(1, 530, 398));

        AddChild(new MetalWall(2, 755, 125));
        AddChild(new MetalWall(2, 965, 125));

        AddChild(new MetalWall(1, 1215, 277));
        AddChild(new MetalWall(2, 1215, 300, -90));
    }

    public override void Update()
    {
        if (Input.GetKeyUp(Key.S))
        {
            Ball ball = new Ball(10);
            ball.position = new Vector2(80, 200);

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

    public Level(string name) : base(name, Settings.ASSET_PATH + "Art/" + name + "Background.png")
    {
        myGame = (MyGame)game;

        AddChild(new PhysicsLine(0, height, width, height));
        AddChild(new PhysicsLine(0, 0, 0, height));
        AddChild(new PhysicsLine(width, height, width, 0));
        AddChild(new PhysicsLine(width, 120, 0, 120));
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
