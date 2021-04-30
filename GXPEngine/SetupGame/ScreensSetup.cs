using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GXPEngine;

public class menu : Scene
{
    public menu() : base("Menu"/*, name + "Background.png"*/)
    {
        //
    }

    public override void onLoad()
    {
        base.onLoad();
        AddChild(new LvSwtchButton(100, 100, "To Settings", "Settings"));
    }
}

public class settings : Scene
{
    public int volume = 10;

    public settings() : base("Settings"/*, name + "Background.png"*/) { }

    Font funt = new Font("Arial", 25);

    public override void onLoad()
    {   
        base.onLoad();
        AddChild(new ControlButton(300, 200, "<", "-"));
        AddChild(new ControlButton(500, 200, ">", "+"));
        AddChild(new LvSwtchButton(400, 400, "Back", "Menu"));
    }
    public override void Update()
    {
        graphics.Clear(Color.Empty);
        graphics.DrawString("volume", funt, Brushes.Violet, 300, 100);
        graphics.DrawString(volume.ToString(), funt, Brushes.Violet, 400, 200);
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