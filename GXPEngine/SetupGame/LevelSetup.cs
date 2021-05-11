using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;
using System.Drawing;

public class Level3 : Level
{
    public Level3() : base("level3")
    {
        name = "level3";
        gravity = new Vector2(0, 500f);
        resistance = 0f;

        plankStock = 5;
        springStock = 4;
        pillowStock = 3;
    }

    public override void onLoad()
    {
        AddChild(new Spikes(30, 0, height - 30));

        AddChild(new Star(105, 680));
        AddChild(new MetalWall(3, 215, 550));

        AddChild(new MetalWall(3, 730, 600));
        AddChild(new MetalWall(2, 730, 600, -90));
        AddChild(new Star(865, 700));
        AddChild(new MetalWall(1, 1135, 600, -90));
        AddChild(new MetalWall(2, 1215, 500));
        AddChild(new Laser(915, 587, -90));

        AddChild(new MetalWall(2, 540, 650));
        AddChild(new MetalWall(2, 538, 360, 90));
        AddChild(new MetalWall(1, 538, 360));
        AddChild(new Laser(360, 125));

        AddChild(new Spikes(4, 965, 170, 180));
        AddChild(new Star(870, 220));
        AddChild(new MetalWall(2, 755, 125));
        AddChild(new MetalWall(2, 965, 125));

        AddChild(new MetalWall(1, 1215, 277));
        AddChild(new MetalWall(3, 1215, 300, -90));

        AddChild(new Objective(125, 125, 1375, 750, "settings"));

        base.onLoad();
    }
}

public class Level2 : Level
{
    public Level2() : base("level1")
    {
        name = "level2";
        gravity = new Vector2(0, 2000f);
        resistance = 0.01f;

        plankStock = springStock = pillowStock = 5;
    }

    public override void onLoad()
    {
        AddChild(new Spikes(30, 0, height - 30));

        AddChild(new MetalWall(3, 250, 75));
        AddChild(new MetalWall(3, 250, 550));
        AddChild(new Laser(300, 350, -90));
        AddChild(new MetalWall(2, 600, 350));
        AddChild(new MetalWall(3, 800, 75));
        AddChild(new MetalWall(3, 800, 550));
        AddChild(new MetalWall(3, 1200, 400, -90));
        AddChild(new Laser(1175, 150));

        base.onLoad();
    }
}

public class Level1 : Level
{
    public Level1() : base("level1")
    {
        gravity = new Vector2(0, 2000f);
        resistance = 0.01f;

        plankStock = springStock = pillowStock = 1;
    }

    public override void onLoad()
    {
        AddChild(new PhysicsLine(0, height, width, height));
        AddChild(new PhysicsLine(0, height + 10, width, height + 10));

        AddChild(new MetalWall(2, 400, 125));
        AddChild(new MetalWall(4, 400, 500));
        AddChild(new MetalWall(4, 800, 125));
        AddChild(new MetalWall(3, 800, 700));

        base.onLoad();
    }
}

public class Level : Scene 
{
    public Camera mainCam;
    public Vector2 gravity;
    public float resistance;
    public int stars;

    protected Sprite panel;
    protected MyGame myGame;

    protected int plankStock;
    protected int springStock;
    protected int pillowStock;

    private AnimationSprite starBar;

    public Level(string name) : base(name, Settings.ASSET_PATH + "Art/" + name + "Background.png")
    {
        myGame = (MyGame)game;
    }

    public override void Update()
    {
        starBar.SetFrame(stars);
        Console.WriteLine(stars);
    }

    private void ReloadStars()
    {
        foreach (GameObject child in GetChildren())
        {
            if (child is Star)
            {
                ((Star)child).StartAgain();
            }
        }

        stars = 0;
    }

    public override void onLoad()
    {
        base.onLoad();

        AddChild(new PhysicsLine(0, 0, 0, height));
        AddChild(new PhysicsLine(width, height, width, 0));
        AddChild(new PhysicsLine(width, 120, 0, 120));
        AddChild(new Cannon(80, 186));

        panel = new Sprite(Settings.ASSET_PATH + "Art/Panel.png", false, false);
        panel.height = 130;

        panel.AddChild(new PlankButton(350, 85, plankStock));
        panel.AddChild(new SpringButton(550, 85, springStock));
        panel.AddChild(new PillowButton(750, 85, pillowStock));

        starBar = new AnimationSprite(Settings.ASSET_PATH + "Art/StarBar.png", 4, 1, 4, false, false);
        starBar.SetXY(1150, 50);
        panel.AddChild(starBar);

        //panel.SetOrigin(0, panel.height);
        //panel.rotation = 90;
        AddChildAt(panel, 1000);

        mainCam = new Camera(0, 0, width, height);
        AddChild(mainCam);
    }

    public override void recieveMessage(string message)
    {
        if (message == "dead")
        {
            ReloadStars();
        }
    }
}
