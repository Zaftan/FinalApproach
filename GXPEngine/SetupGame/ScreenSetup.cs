using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Managers;

public class Menu : Screen
{
    public Menu() : base("Menu"/*, name + "Background.png"*/)
    {
        //
    }

    public override void onLoad()
    {
        base.onLoad();
        AddChild(new ButtenAssembly(200, 100));
    }
}

public class SettingScreen : Screen
{
    public int volume = 10;

    public SettingScreen() : base("Settings") { }

    Font font = new Font("Poetsen One", 25);

    public override void onLoad()
    {   
        Sprite sprite = new Sprite(Settings.ASSET_PATH + "Art/Music.png");

        sprite.x = 75;
        sprite.y = 75;

        AddChild(sprite);
        AddChild(new ControlButton(200, 225, "-", "Minus.png"));
        AddChild(new ControlButton(700, 225, "+", "Plus.png"));
        AddChild(new BackButton(400, 400));

        base.onLoad();
    }

    public override void Update()
    {
        overlay.graphics.Clear(Color.Empty);
        overlay.graphics.DrawString(volume.ToString(), font, Brushes.White, 400, 225);
    }

    public override void recieveMessage(string message)
    {
        if(!(volume < 0) || (volume > 10))
        {
            if(volume == 0)
            {
                //
            }
            else
            {
                if(message == "-")
                {
                    volume--;
                }
            }
            if (volume == 10)
            {
                //
            }
            else
            {
                if (message == "+")
                {
                    volume++;
                }
            }
        }

        Settings.volume = volume;
    }
}

public class Screen : Scene
{
    protected Canvas overlay;

    public Screen(string name) : base(name, Settings.ASSET_PATH + "Art/menuBackground.png")
    {
    }

    public override void onLoad()
    {
        base.onLoad();

        overlay = new Canvas(width, height, false);
        AddChild(overlay);
    }
}