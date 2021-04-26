using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;                                // GXPEngine contains the engine

public class MyGame : Game
{
	public SoundChannel soundChannel;
	Level level1;

	public MyGame() : base(1920, 1080, false, false)
	{
		targetFps = 60;

		_sceneManager.addscene(new EngineTest());
	}

    void Update()
	{

		//Console.WriteLine("FPS: " + currentFps);
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}