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

        AddChild(new MetalWall(3, 215, 550));

        AddChild(new MetalWall(3, 730, 600));
        AddChild(new MetalWall(2, 730, 600, -90));
        AddChild(new MetalWall(1, 1135, 600, -90));
        AddChild(new MetalWall(2, 1215, 500));
        AddChild(new Destroyer(915, 587, -90));

        AddChild(new MetalWall(2, 540, 650));
        AddChild(new MetalWall(2, 538, 360, 90));
        AddChild(new MetalWall(1, 538, 360));
        AddChild(new Destroyer(360, 125));

        AddChild(new MetalWall(2, 755, 125));
        AddChild(new MetalWall(2, 965, 125));

        AddChild(new MetalWall(1, 1215, 277));
        AddChild(new MetalWall(2, 1215, 300, -90));
    }

    public override void Update()
    {
    }
}

public class Level : Scene 
{
    public Camera mainCam;
    public Vector2 gravity;

    protected MyGame myGame;

    public Level(string name) : base(name, Settings.ASSET_PATH + "Art/" + name + "Background.png")
    {
        myGame = (MyGame)game;
    }

    public override void Update()
    {
    }

    public override void onLoad()
    {
        base.onLoad();

        mainCam = new Camera(0, 0, width, height);
        AddChild(mainCam);

        AddChild(new PhysicsLine(0, height - 70, width, height - 70));
        AddChild(new PhysicsLine(0, height + 65, width, height + 65));
        AddChild(new PhysicsLine(0, 0, 0, height));
        AddChild(new PhysicsLine(width, height, width, 0));
        AddChild(new PhysicsLine(width, 120, 0, 120));

        AddChild(new PlankButton(350, 50));
        AddChild(new SpringButton(550, 50));
        AddChild(new PillowButton(750, 50));

        AddChild(new Cannon(80, 186));
    }

    public override void onLeave()
    {
        base.onLeave();
    }
}
