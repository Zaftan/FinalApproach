using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;
using GXPEngine;

public class Mouse : GameObject
{
    Vector2 position;
    Vector2 oldPosition;

    Vector2 direction
    {
        get { return position - oldPosition; }
    }

    public Mouse() : base(false)
    {
    }

    public void Update()
    {
        oldPosition = position;
        SetXY(Input.mouseX, Input.mouseY);
        position = new Vector2(x, y);

        if (Input.GetMouseButtonUp(0))
        {
            release();
        }
    }

    private void release()
    {
        foreach (GameObject child in GetChildren())
        {
            if (child is Placable)
            {
                ((Placable)child).SetXY(position.x, position.y);
                game.Currentscene.AddChild(child);
            }
        }
    }

    public void recieve(Placable placable)
    {
        if (GetChildren().Count <= 1)
        {
            AddChild(placable);
        }
    }
}

