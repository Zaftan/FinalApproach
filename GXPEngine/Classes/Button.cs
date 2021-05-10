using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

class LvSwtchButton : Button
{
    private string nextLevel;

    public string level
    {
        set { nextLevel = value; }
    }

    public LvSwtchButton(float inpX, float inpY, string txt, Scene nextLevelInp, string path) : base(inpX, inpY, txt, path)
    {
        nextLevel = nextLevelInp.name;
        text = nextLevelInp.name;
    }

    public LvSwtchButton(float inpX, float inpY, string txt, string nextLevelInp, string path) : base(inpX, inpY, txt, path)
    {
        nextLevel = nextLevelInp;
        text = nextLevelInp;
    }

    public LvSwtchButton(int inpX, int inpY, string txt) : base(inpX, inpY, txt)
    {
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
    }
}

public class ControlButton : Button
{
    protected string message;

    public ControlButton(float inpX, float inpY, string txt, string action, string path) : base(inpX, inpY, txt, path)
    {
        message = action;
    }

    protected override void click()
    {
        base.click();
        parent.recieveMessage(message);
    }
}


public class Button : AnimationSprite
{
    private Canvas overlay;
    protected string text;

    public Button(float inpX, float inpY, string txt, string path = "button.png") : base(Settings.ASSET_PATH + "Art/" + path, 1, 1, 1, false)
    {
        //overlay = new Canvas(width, height);
        //overlay.SetOrigin(overlay.width / 2, overlay.height / 2);
        //AddChild(overlay);

        x = inpX;
        y = inpY;
        SetOrigin(width / 2, height / 2);

        text = txt;
    }

    protected virtual void click()
    {
    }

    public void Update()
    {
        var _newFont = new Font("Pangolin", 15);
        //overlay.graphics.Clear(Color.Empty);
        //overlay.graphics.DrawString(text, _newFont, Brushes.White, 90, 50);

        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            SetFrame(1);
            //overlay.y = 0;
            //overlay.x = 0;

            if (Input.GetMouseButtonUp(0))
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
