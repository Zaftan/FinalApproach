using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;                                // GXPEngine contains the engine

public class MyGame : Game
{
	public SoundChannel soundChannel;
	public int volume = 10;
	public Mouse mouse;

	public MyGame() : base(960, 540, false, false)
	{
		targetFps = 60;

		mouse = new Mouse();
		AddChild(mouse);

        _sceneManager.addscene(new menu());
		_sceneManager.addscene(new settings());
		_sceneManager.addscene(new EngineTest());

		_sceneManager.addscene(new Level("Temp"));
	}

    void Update()
	{

		if (Input.GetKeyDown(Key.R))
		{
			game.SceneManager.Reloadscene();
		}
		if (Input.GetKeyDown(Key.RIGHT))
		{
			game.SceneManager.GotoNextscene();
		}
		if (Input.GetKeyDown(Key.LEFT))
		{
			game.SceneManager.GotoPreviousscene();
		}

		//Console.WriteLine("FPS: " + currentFps);
		soundChannel = new Sound(".mp3").Play(false, 0, volume, 0);
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}