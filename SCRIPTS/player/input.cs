using Godot;
using System;

public partial class input : Node
{
    // GAME OBJECTS : 
	Node player;
	
	
	// PATHS : 
	string player_path = "../";
	
	
	// VALUES : 
	
	
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    	player = GetNode(player_path);
		
		Godot.Input.MouseModeEnum mm = Godot.Input.MouseModeEnum.Captured;
		Godot.Input.SetMouseMode(mm);
    }

	// Called when an input event occurs ,
	public override void _Input(InputEvent ev)
	{
		InputEventMouseMotion mm = new InputEventMouseMotion();
		if(ev.GetType() == mm.GetType())
		{
			mm = (InputEventMouseMotion)ev;
			player.Call(method: "Look" , args: mm.Relative);
		}
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	    CheckKeyboardInputs();
		
	}
	
	void CheckKeyboardInputs()
	{
	
		// PRESSED : 
		
		if(Input.IsActionPressed("playerForward"))
		{
			player.Call(method: "Move" , 0);
		}
		
		if(Input.IsActionPressed("playerBackward"))
		{
			player.Call(method: "Move" , 1);
		}
		
		if(Input.IsActionPressed("playerLeft"))
		{
			player.Call(method: "Move" , 2);			
		}
		
		if(Input.IsActionPressed("playerRight"))
		{
			player.Call(method: "Move" , 3);		
		}
		
		if(Input.IsActionJustPressed("playerJump"))
		{
			player.Call(method: "Jump");
		}
		
		// JUST RELEASED : 
		if(Input.IsActionJustReleased("playerForward") || Input.IsActionJustReleased("playerBackward") || Input.IsActionJustReleased("playerLeft") || Input.IsActionJustReleased("playerRight"))
		{
			player.Call(method: "Stop");
		}
		
	}
}














































