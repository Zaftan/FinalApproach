using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class PillowButton : PlacementButtons
{
    public PillowButton(float inpX, float inpY) : base(inpX, inpY, "PillowButton")
    {
    }

    protected override void click()
    {
        ((MyGame)game).mouse.recieve(new Pillow());
    }
}

public class SpringButton : PlacementButtons
{
    public SpringButton(float inpX, float inpY) : base(inpX, inpY, "Springbutton")
    {
    }

    protected override void click()
    {
        ((MyGame)game).mouse.recieve(new Spring());
    }
}

public class PlankButton : PlacementButtons
{
    public PlankButton(float inpX, float inpY) : base(inpX, inpY, "PlankButton")
    {
    }

    protected override void click()
    {
        Console.WriteLine("CLICK");
        ((MyGame)game).mouse.recieve(new Plank());
    }
}

public abstract class PlacementButtons : Button
{
    protected PlacementButtons(float inpX, float inpY, string path) : base(inpX, inpY, "", path + ".png", 2)
    {
        
    }
}

