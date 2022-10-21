using Godot;
using System;

public partial class Ground : StaticBody3D
{
	// GAME OBJECTS : 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.AddToGroup("damage_effect_playable");
		// members of this group allow the bullet to play the damage effect particles , when bullet collides with them.
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}


