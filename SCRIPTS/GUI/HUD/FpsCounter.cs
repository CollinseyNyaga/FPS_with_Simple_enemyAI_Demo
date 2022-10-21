using Godot;
using System;

public partial class FpsCounter : Control
{
	// GAME OBJECTS : 
	Timer fpsTimer;
	Label fpsLabel;
	
	// PATHS : 
	string fps_timer_path = "Timer";
	string fps_label_path = "HBoxContainer/value";
	
	// VALUES : 
	int currentFpsCount = 0;
	public int Fps = 0;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		fpsTimer = (Timer)GetNode(fps_timer_path);
		fpsTimer.Start();
		
		fpsLabel = (Label)GetNode(fps_label_path);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		currentFpsCount = currentFpsCount + 1;
	}
	
	public void FpsTimerTimedOut()
	{
		// set fps property : 
		Fps = currentFpsCount;
		
		// reset fps count : 
		currentFpsCount = 0;
		
		// update the fps label on the gui : 
		UpdateFpsLabel();
		
		// GD.Print(Fps);
	}
	
	void UpdateFpsLabel()
	{
		fpsLabel.Text = $"{Fps}";
	}
	
}






