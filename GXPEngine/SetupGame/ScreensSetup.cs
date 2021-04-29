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
    public settings() : base("Settings"/*, name + "Background.png"*/) { }

    public override void onLoad()
    {   
        base.onLoad();
        Button buttVolDown = new Button(300, 200, "<");
        AddChild(buttVolDown);
        Font funt = new Font("Arial", 25);
        graphics.DrawString("volume", funt, Brushes.Violet, 300, 100);
        //graphics.DrawString(volume.ToString(), funt, Brushes.Violet, 400, 200);
        AddChild(new Button(500, 200, ">"));
        AddChild(new LvSwtchButton(400, 400, "Back", "Menu"));

    }
}

class Screen : Scene
{
    public Screen(string name, string fileName) : base(name, fileName)
    {
    }
}