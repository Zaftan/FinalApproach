using System;
using System.Collections.Generic;
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
        AddChild(new LvSwtchButton(100, 100, "uno", "Settings"));
    }
}

public class settings : Scene
{
    public settings() : base("Settings"/*, name + "Background.png"*/) { }

    public override void onLoad()
    {
        base.onLoad();
        AddChild(new Button(300, 300, "dos"));

    }
}

class Screen : Scene
{
    public Screen(string name, string fileName) : base(name, fileName)
    {
    }
}