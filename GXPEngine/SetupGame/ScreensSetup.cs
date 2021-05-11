using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Managers;

public class menu : Scene
{
    public menu() : base("Menu"/*, name + "Background.png"*/)
    {
        //
    }

    public override void onLoad()
    {
        base.onLoad();
        AddChild(new LvSwtchButton(100, 100, "", new settings(), "Options.png"));
    }
}

public class settings : Scene
{
    public float volume = 10;

    public settings() : base("Settings") { }

    Font funt = new Font("Arial", 25);

    public override void onLoad()
    {   
        base.onLoad();
        Sprite sprite = new Sprite(Settings.ASSET_PATH + "Art/Music.png");
        sprite.x = 175;
        sprite.y = 150;
        AddChild(sprite);
        AddChild(new ControlButton(300, 300, "<", "-", "Minus.png"));
        AddChild(new ControlButton(800, 300, ">", "+", "Plus.png"));
        AddChild(new LvSwtchButton(600, 500, "", new menu(), "Back.png"));
    }

    public override void Update()
    {
        graphics.Clear(Color.Empty);
        graphics.DrawString(volume.ToString(), funt, Brushes.White, 400, 100);
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
    }
}

class Screen : Scene
{
    public Screen(string name, string fileName) : base(name, fileName)
    {
    }
}