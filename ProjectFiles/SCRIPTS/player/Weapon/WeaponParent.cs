using Godot;
using System;

public partial class WeaponParent : Node3D
{
   	// GAME OBJECTS : 
	Node currentWeapon;

	
	// PATHS : 
	
	
	
	// VALUES : 
	


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // set current weapon : 
		currentWeapon = GetNode("smg1");
		
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
    	CheckKeyboardInputs();
	}

	void CheckKeyboardInputs()
	{
		if(Input.IsActionJustPressed("playerFire"))
		{
			currentWeapon.Call("Fire");
		}
		
		if(Input.IsActionJustReleased("playerFire"))
		{
			currentWeapon.Call("StopFire");			
		}
	}
	
}


















