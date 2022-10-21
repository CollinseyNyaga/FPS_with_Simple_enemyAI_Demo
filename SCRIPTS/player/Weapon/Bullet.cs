using Godot;
using System;

public partial class Bullet : CharacterBody3D
{
	// GAME OBJECTS : 
	Timer lifetime_timer;
	Node damageEffect;
	
	
	// PATHS : 
	string lifetime_timer_path = "lifetime_timer";
	string damage_effect_path = "damage_effect";
	
	// VALUES : 
	Vector3 velocity;
	float speed = 250f;
	float lifeTime = 0.8f;
	
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.AddToGroup("bullets");
	
		lifetime_timer = (Timer)GetNode(lifetime_timer_path);
		lifetime_timer.WaitTime = lifeTime;
		lifetime_timer.Start();
		
		damageEffect = GetNode(damage_effect_path);
	}

	public override void _PhysicsProcess(double delta)
	{
		Accelerate();
	}
	
	public void PositionSelf(Node3D spawnPoint , Node3D player , Node3D player_cam)
	{
		// set position according to spawnPoint passed in the method : 
		Transform3D newT = this.GlobalTransform;
		newT.origin = spawnPoint.GlobalTransform.origin;
		this.GlobalTransform = newT;
	
		// set rotation in the y and x axis according to the direction that player and cam is facing : 
		Vector3 newRot = player.Rotation;
		newRot.y = player.Rotation.y;
		newRot.x = player_cam.Rotation.x;
		this.Rotation = newRot;
	
	
		// set bullet direction : 
		velocity = -this.GlobalTransform.basis.z * speed;
		
	   	// GD.Print("spawned");
	}
	
	void Accelerate()
	{
		MoveAndSlide();
	}
	
	public void lifeTimeTimerTimedOut()
	{
		this.QueueFree();
	}
	
	public void PlayDamageEffect()
	{
		// called externally mostly by hitboxes , to play the damage effect (particle)
		damageEffect.Call("PlayEffect");
	}

}








































