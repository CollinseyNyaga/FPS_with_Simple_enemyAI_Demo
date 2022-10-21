using Godot;
using System;

public partial class Grenade : Node3D
{
	// GAME OBJECTS : 
	RigidBody3D grenadeRB;
	Timer blastTimer;
	Node3D blastArea;
	
	Node3D spawnPoint; 
	Node3D player;
	Node explosionEffect;
	
	
	// PATHS : 
	string grenade_rb_path = "RigidBody3D";
	string blast_timer_path = "blastTimer";
	string blast_area_path = "RigidBody3D/blastArea";
	string explosion_effect_path = "RigidBody3D/explosionEffect";
	
	
	// VALUES : 
	float explosionRadius = 20f;
	
	float grenadeLaunchForce = 20f;
	bool isThrown = false;
	float timeToBlast = 4f;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// get and start the grenade blast timer : 
		blastTimer = (Timer)GetNode(blast_timer_path);
		blastTimer.WaitTime = timeToBlast;
		blastTimer.Start();
		
		// hide this node because it is only spawned , but the player is holding it: 
		this.Visible = false;
		
		grenadeRB = (RigidBody3D)GetNode(grenade_rb_path);
		FreezeGrenadeRB();
		
		// get blast area and reset its scale , so it can not damage anything
		blastArea = (Node3D)GetNode(blast_area_path);
		blastArea.Scale = new Vector3();
		
		explosionEffect = GetNode(explosion_effect_path);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		SetPosition();
		CheckExplosionEffect();
	}
	
	public void InitializeValues(Node3D spawnpoint , Node3D plyr)
	{
		spawnPoint = spawnpoint;
		player = plyr;
	}
	
	void SetPosition()
	{
		// the position of the current node3d node is set only when the grenade is not thrown.
		// after its thrown , the position is not set , because of interference with physics of the rb grenade .
		if(isThrown == false)
		{
			if(spawnPoint != null)
			{
				// set translation : 
				Transform3D newT = this.GlobalTransform;
				newT.origin = spawnPoint.GlobalTransform.origin;
				
				this.GlobalTransform = newT;
			}
		
			if(player != null)
			{
				// set rotation in the y axis:
				Vector3 currentRot = this.Rotation;
				this.LookAt(player.GlobalTransform.origin);
				this.Rotation = new Vector3(currentRot.x , this.Rotation.y , currentRot.z);
			}
		}
	}
	
	void LaunchGrenadeRigidBody()
	{
		isThrown = true;
		UnFreezeGrenadeRB();
		this.Visible = true;
	
		Vector3 throwForce = this.GlobalTransform.basis.z * grenadeLaunchForce;
		grenadeRB.ApplyCentralImpulse(impulse: throwForce);
	}
	
	public void BlastTimerTimedOut()
	{
		Explode();
		blastTimer.Stop();	
	}
	
	void Explode()
	{
		// set explosion radius scale : 
		Vector3 newBlastRadiusScale = new Vector3(explosionRadius , explosionRadius , explosionRadius);
		blastArea.Scale = newBlastRadiusScale;
		
		// play explosion animation :
		explosionEffect.Call(method: "StartEffect");
		
	}
	
	public void BodyEnteredBlastArea(Node body)
	{
		if(body.IsInGroup("enemy") == true)
		{
			body.Call(method: "TakeDamage" , args: 100);
		}
		
		if(body is Player == true)
		{
			body.Call(method: "TakeDamage" , args: 60);
		}
	}
	
	void FreezeGrenadeRB()
	{
		grenadeRB.Freeze = true;
	}
	
	void UnFreezeGrenadeRB()
	{
		grenadeRB.Freeze = false;
	}
	
	public void beepTimerTimedOut()
	{
		// when beep timer times out , increase the playback speed of the animation player that plays the grenade tick animations : 
		AnimationPlayer anim = (AnimationPlayer)GetNode("AnimationPlayer");
		anim.PlaybackSpeed = anim.PlaybackSpeed * 2f;
	}
	
	public void EndSelf()
	{
		this.QueueFree();
	}
	
	void CheckExplosionEffect()
	{
		bool hasPlayed = (bool)explosionEffect.Get(property: "Finished");
		if(hasPlayed == true)
		{
			// when the explosion effect has finished playing :
			EndSelf();
		}
	}
}













