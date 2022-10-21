using Godot;
using System;

public partial class PauseMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.Node.ProcessModeEnum pm = Godot.Node.ProcessModeEnum.Always;
		this.ProcessMode = pm;
	
		SetPause(1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CheckKeyboardInputs();
	}
	
	void CheckKeyboardInputs()
	{
		if(Input.IsActionJustReleased("pause_game"))
		{
			TogglePause();
		}
	}
	
	
	void TogglePause()
	{
		bool paused = GetTree().Paused;
		if(paused == true)
		{
			SetPause(0);
		}
		else
		{
			SetPause(1);
		}
	}
	
	public void SetPause(int val)
	{
		// pause mode can either be two values , 1 or 0. val = 1 is pause mode = true
		if(val == 1)
		{
			// pause : 
			GetTree().Paused = true;
			this.Visible = true;
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}
		else
		{
			// unpause :
			GetTree().Paused = false;
			this.Visible = false;
			Input.MouseMode = Input.MouseModeEnum.Captured;
		}
	}
	
	public void Action(string name)
	{
		// name is the name of the button that has been clicked .
		GD.Print($"clicked {name}");
		
		switch(name)
		{
			case "Resume" : 
				TogglePause();
				break;
				
			case "Settings" : 
				break;
				
			case "Quit" : 
				GetTree().Quit();
				break;
				
			default : 
				break;
		}
	}
}












