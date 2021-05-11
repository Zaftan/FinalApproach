﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;
using System.Drawing;

public class Level2 : Level
{
    public AnimationSprite rocket = new AnimationSprite(Settings.ASSET_PATH + "Art/RocketshipAnimation.png", 6, 3);

    public Level2() : base("level2")
    {
        gravity = new Vector2(0, 2000f);
    }

    public override void onLoad()
    {
        Destructor bottemDestructor = new Destructor(width, 50, width/2, height - 25);
        bottemDestructor.SetColor(System.Drawing.Color.Red);
        AddChild(bottemDestructor);
        AddChild(new MetalWall(3, 215, 550));

        AddChild(new MetalWall(3, 730, 600));
        AddChild(new MetalWall(2, 730, 600, -90));
        AddChild(new MetalWall(1, 1135, 600, -90));
        AddChild(new MetalWall(2, 1215, 500));
        AddChild(new Laser(915, 587, -90));

        AddChild(new MetalWall(2, 540, 650));
        AddChild(new MetalWall(2, 538, 360, 90));
        AddChild(new MetalWall(1, 538, 360));
        AddChild(new Laser(360, 125));

        AddChild(new MetalWall(2, 755, 125));
        AddChild(new MetalWall(2, 965, 125));

        AddChild(new MetalWall(1, 1215, 277));
        AddChild(new MetalWall(3, 1215, 300, -90));

        //AddChild(new Destroyer(20, 180, 925, 585, -90));

        AddChild(new Objective(125, 125, 1375, 750, "settings"));

        rocket.scaleX = 0.5f;
        rocket.scaleY = 0.5f;
        AddChild(rocket);
        rocket.SetXY(1275, 650);

        base.onLoad();
    }

    public override void Update()
    {
    }
}

public class Level : Scene 
{
    public Camera mainCam;
    public Vector2 gravity;

    protected Sprite panel;
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

/*        AddChild(new PhysicsLine(0, height - 50, width, height - 50));
        AddChild(new PhysicsLine(0, height + 45, width, height + 45));*/
        AddChild(new PhysicsLine(0, 0, 0, height));
        AddChild(new PhysicsLine(width, height, width, 0));
        AddChild(new PhysicsLine(width, 120, 0, 120));
        AddChild(new Cannon(80, 186));

        panel = new Sprite(Settings.ASSET_PATH + "Art/Panel.png", false, false);
        panel.height = 130;

        panel.AddChild(new PlankButton(350, 85));
        panel.AddChild(new SpringButton(550, 85));
        panel.AddChild(new PillowButton(750, 85));

        //panel.SetOrigin(0, panel.height);
        //panel.rotation = 90;
        AddChildAt(panel, 1000);

        mainCam = new Camera(0, 0, width, height);
        AddChild(mainCam);
    }

    public override void onLeave()
    {
        base.onLeave();
    }
}
