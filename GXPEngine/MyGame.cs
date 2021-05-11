using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;                                // GXPEngine contains the engine

public class MyGame : Game
{
	public SoundChannel soundChannel;
	private settings sc;
	public Mouse mouse;

	public MyGame() : base(1440, 810, false, false)
	{
		targetFps = 60;

		mouse = new Mouse();
		AddChildAt(mouse, 100);

		//_sceneManager.addscene(new menu());
		//_sceneManager.addscene(new settings());
		_sceneManager.addscene(new Level1());
		_sceneManager.addscene(new Level2());
		sc = new settings();
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
		soundChannel = new Sound(".mp3").Play(false, 0, sc.volume, 0);
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}