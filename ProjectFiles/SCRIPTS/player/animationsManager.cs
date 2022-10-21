using Godot;
using System;

public partial class animationsManager : Node
{
	// GAME OBJECTS : 
	AnimationPlayer playerArmAnim;
	AnimationPlayer playerAnim;
	
	
	
	// PATHS : 
	string player_arm_anim_path = "../cam/Arm/AnimationPlayer";
	string player_anim_path = "../AnimationPlayer";
	
	// VALUES : 
	
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		playerArmAnim = (AnimationPlayer)GetNode(player_arm_anim_path);
		playerAnim = (AnimationPlayer)GetNode(player_anim_path);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public void ThrowGrenade()
	{
		// GD.Print("throw");
		playerArmAnim.Play(name: "throw");		
	}
	
	public void HoldGrenade()
	{
		// GD.Print("hold");
		playerArmAnim.Play(name: "hold");
	}
	
	public void Run()
	{
		// plays run animation : 
		playerAnim.Play(name: "running");
	}
	
	public void StopRun()
	{
		playerAnim.Stop();
		playerAnim.Play(name: "RESET");
	}
}


















