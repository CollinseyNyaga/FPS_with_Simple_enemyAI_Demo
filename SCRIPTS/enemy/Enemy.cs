using Godot;
using System;

public partial class Enemy : CharacterBody3D
{
    // GAME OBJECTS : 
	Node enemyCharacter;
	Node3D targetLookObject;
	Tween velocityTween;
	Node animationManager;
	
	
	// PATHS : 
	string animation_manager_path = "animationManager";
	
	
	// VALUES : 
	float gravity = -20f;
	
	int Health = 100;
	
	float speed = 20f;
	bool move = false;
	bool stop = false;
	
	bool lookAtTarget = false;
	float stopDuration = 0.05f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
		this.AddToGroup("enemy");
		velocityTween = this.GetTree().CreateTween();
	
        GetEnemyCharacter();
		animationManager = GetNode(animation_manager_path);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CheckHealth();
		ApplyGravity();
    	ApplyForces();
		
		LookAtTarget();
		MoveToTarget();
	}

	void GetEnemyCharacter()
	{
		Godot.Collections.Array<Godot.Node> character_children = GetNode("character").GetChildren();
		enemyCharacter = (Node)character_children[0];
	}


	void LookAtTarget()
	{
		if(lookAtTarget == true)
		{
			// the enemy should only look at the player in the y axis : 
			Vector3 currentRot = this.Rotation;
			
			this.LookAt(targetLookObject.GlobalTransform.origin , new Vector3(0,1,0));
			
			// cancel rotations in axes other than y : 
			this.Rotation = new Vector3(currentRot.x , this.Rotation.y , currentRot.z);
		}
	}

	
	void ApplyForces()
	{
		this.MoveAndSlide();
	}
	
	void ApplyGravity()
	{
		Vector3 newVelocity = this.Velocity;
	
		if(IsOnFloor() == false)
		{
			newVelocity.y = gravity;
		}
		else
		{
			newVelocity.y = gravity;
		}
		
		this.Velocity = newVelocity;
		
	}
	
	public void TakeDamage(int amount)
	{
		Health = Health - amount;
		PlayDamageEffects();
	}
	
	void CheckHealth()
	{
		if(Health <= 0)
		{
			this.QueueFree();
		}
	}
	
	void PlayDamageEffects()
	{
		// get damage effects : 
		Godot.Collections.Array<Node> damageEffects = enemyCharacter.GetNode("DamageEffects").GetChildren();
		
		// play effects by calling animationPlayer for each damageEffects children : 
		for(int i = 0; i < damageEffects.Count ; i++)
		{
			Node effect = (Node)damageEffects[i];
			effect.Call("PlayEffect");
		}
	}
	
	public void StartMove()
	{
		move = true;
		
		if(animationManager != null)
			animationManager.Call("Run");
	}
	
	public void Stop()
	{
		// stop moving:
		stop = true;
		move = false;
		
		// idle animation should not be played immediately , because it will stop abruptly. Instead , animationManager 
		// is triggered to play idle animation when velocity.x and velocity.z == 0
		
	}
	
	
	public void SetLookTarget(Node3D lookTarget)
	{
		targetLookObject = lookTarget;
		lookAtTarget = true;
	}
	
	public void StopLookTarget()
	{
		lookAtTarget = false;
	}
	
	void MoveToTarget()
	{
		if(move == true)
		{
			Vector3 newVelocity = this.Velocity;
			newVelocity = -speed * this.GlobalTransform.basis.z;
			this.Velocity = newVelocity;
			
			ApplyGravity();
		}
		
	}
	
	void Attack()
	{
		animationManager.Call(method: "BeginAttackMode");
	}
	
	
}
















































































































