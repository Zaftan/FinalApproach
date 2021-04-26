using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Timer : GameObject
{
    public float maxSeconds;
    float second;
    int framesCounter;
    bool active;
    public bool done;

    public float seconds
    {
        get { return second; }
    }

    public Timer() : base()
    {
        start();
    }

    public Timer(float setMaxSeconds) : base()
    {
        maxSeconds = setMaxSeconds;
        start();
    }

    public void start()
    {
        done = false;
        second = 0;
        framesCounter = 0;
        active = true;
    }

    public void stop()
    {
        second = 0;
        framesCounter = 0;
        active = false;
    }

    public void Update()
    {
        if (active)
        {
            if (framesCounter >= 3)
            {
                framesCounter = 0;
                second += 0.05f;
            }
            else
            {
                framesCounter++;
            }

            if (seconds >= maxSeconds && maxSeconds != -1)
            {
                stop();
                done = true;
            }
        }
    }
}

