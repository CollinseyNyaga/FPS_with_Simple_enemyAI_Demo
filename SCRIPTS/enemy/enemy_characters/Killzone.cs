using Godot;
using System;

public partial class Killzone : Node3D
{
    // GAME OBJECTS : 
	Timer damageTimer;
	Node player;
	
	
	// PATHS : 
	string damage_timer_path = "damageTimer";
	
	
	// VALUES : 
	float damageTimeInterval = 0.5f;
	int damageValue = 5;
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        damageTimer = (Timer)GetNode(damage_timer_path);
		damageTimer.WaitTime = damageTimeInterval;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(double delta)
//  {
//      
//  }

	public void BodyEnteredArea(Node body)
	{
		if(body is Player)
		{
			// start the damage timer : 
			damageTimer.Start();
			player = body;
		}
	}
	
	public void BodyExitedArea(Node body)
	{
		if(body is Player)
		{
			damageTimer.Stop();
		}
	}
	
	public void damageTimerTimedOut()
	{
		player.Call(method: "TakeDamage" , args: damageValue);
	}
}






