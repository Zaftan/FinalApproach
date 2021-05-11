using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

public class ButtenAssembly : GameObject
{
    public ButtenAssembly(int pX, int pY) : base(false)
    {
        x = pX;
        y = pY;

        AddChild(new LvSwtchButton(0, 0, new Menu(), "Menu.png", 2));
        AddChild(new LvSwtchButton(0, 80, new SettingScreen(), "Options.png", 2));
        AddChild(new ResetButton(0, 160));
    }
}

class LvSwtchButton : Button
{
    private string nextLevel;

    public string level
    {
        set { nextLevel = value; }
    }

    public LvSwtchButton(float inpX, float inpY, Scene nextLevelInp, string path, int cols = 1) : base(inpX, inpY, path, cols)
    {
        nextLevel = nextLevelInp.name;
        //text = nextLevelInp.name;
    }

    public LvSwtchButton(float inpX, float inpY, string nextLevelInp, string path) : base(inpX, inpY, path)
    {
        nextLevel = nextLevelInp;
        //text = nextLevelInp;
    }

    protected override void click()
    {
        if (nextLevel != null)
        {
            game.SceneManager.SetScene(nextLevel);
        }
        else
        {
            base.click();
        }
        new Sound(Settings.ASSET_PATH + "SFX/Button.wav").Play(false, 0, 10, 0);
    }
}

public class ControlButton : Button
{
    protected string message;

    public ControlButton(float inpX, float inpY, string action, string path) : base(inpX, inpY, path, 2)
    {
        message = action;
    }

    protected override void click()
    {
        base.click();
        parent.recieveMessage(message);
        new Sound(Settings.ASSET_PATH + "SFX/Button.wav").Play(false, 0, 10, 0);
    }
}

public class BackButton : Button
{
    public BackButton(float inpX, float inpY) : base(inpX, inpY, "Back.png", 2)
    {
    }

    protected override void click()
    {
        game.SceneManager.GotoPreviousscene();
    }
}

public class ResetButton : Button
{
    public ResetButton(float inpX, float inpY) : base(inpX, inpY, "Reset.png", 2)
    {
    }

    protected override void click()
    {
        game.SceneManager.Reloadscene();
    }
}

public class Button : AnimationSprite
{
   //private Canvas overlay;

    public Button(float inpX, float inpY, string path = "button.png", int cols = 1) : base(Settings.ASSET_PATH + "Art/" + path, cols, 1, cols, false)
    {
        //overlay = new Canvas(width, height);
        //overlay.SetOrigin(overlay.width / 2, overlay.height / 2);
        //AddChild(overlay);

        x = inpX;
        y = inpY;
        SetOrigin(width / 2, height / 2);
    }

    protected virtual void click()
    {
        //
    }

    public virtual void Update()
    {
        //var _newFont = new Font("Pangolin", 15);
        //overlay.graphics.Clear(Color.Empty);
        //overlay.graphics.DrawString(text, _newFont, Brushes.White, 90, 50);

        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            SetFrame(1);
            //overlay.y = 0;
            //overlay.x = 0;

            if (Input.GetMouseButtonDown(0))
            {
                click();
            }
        }
        else
        {
            SetFrame(0);
            //overlay.y = -3;
            //overlay.x = 1;
        }
    }
}