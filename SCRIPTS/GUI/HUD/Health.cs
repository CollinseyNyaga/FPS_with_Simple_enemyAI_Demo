using Godot;
using System;

public partial class Health : Control
{
	// GAME OBJECTS : 
	Node player;
	Control innerBar;
	
	
	// PATHS : 
	string player_path = "../../../Player";
	string inner_bar_path = "outer_bar/inner_bar";
	
	
	// VALUES : 
	
	
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode(player_path);
		innerBar = (Control)GetNode(inner_bar_path);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		SetBarValue();
	}
	
	int GetPlayerHealth()
	{
		int health = (int)player.Get(property: "Health");
		return health;
	}
	
	void SetBarValue()
	{
		Vector2 newS = innerBar.Scale;
		newS.x = (float)GetPlayerHealth() / 100;
		newS.x = Godot.Mathf.Clamp(value: newS.x , min: 0, max: 1);
		
		innerBar.Scale = newS;
		
	}
}


