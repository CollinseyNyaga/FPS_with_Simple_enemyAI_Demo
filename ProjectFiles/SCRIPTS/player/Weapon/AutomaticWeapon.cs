using Godot;
using System;

public partial class AutomaticWeapon : Node3D
{
    // GAME OBJECTS : 
	Timer bulletSpawnTimer;
	Node mesh;
	AnimationPlayer meshAnim;
	Node muzzleFlash;
	RayCast3D bulletRayCast;
	
	
	// PATHS : 
	string bullet_spawn_timer_path = "AutoWeaponTimer";
	string mesh_path = "mesh";
	string muzzle_flash_path = "muzzle_flash";
	string bullet_raycast_path = "bulletRayCast";
	
	
	// VALUES : 
	float bulletSpawnInterval = 0.1f;
	int damageAmount = 20;
	
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        bulletSpawnTimer = (Timer)GetNode(bullet_spawn_timer_path);
		bulletSpawnTimer.WaitTime = bulletSpawnInterval;
		
		mesh = GetNode(mesh_path);
		GetMeshAnim();
		
		muzzleFlash = GetNode(muzzle_flash_path);
		
		bulletRayCast = (RayCast3D)GetNode(bullet_raycast_path);
    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AutoWeaponTimerTimedOut()
	{
		// called when the auto weapon timer times out: 
		FireBullet();
	}
	
	void Fire()
	{
		// called externally when the input for firing (LMB) is pressed :
		FireBullet();		
		bulletSpawnTimer.Start();
	}
	
	void StopFire()
	{
		bulletSpawnTimer.Stop();
	}
	
	void FireBullet()
	{
		// play the weapon mesh fire animation :
		meshAnim.Play("fire_animation");
		
		// muzzle flash : 
		muzzleFlash.Call(method: "Flash");
	
		// get the collision object that is colliding with the bulletRayCast3D : 
		Node hitObject = (Node)bulletRayCast.GetCollider();
	
		if(hitObject != null)
		{
			if(hitObject.IsInGroup("enemy") == true)
			{
				hitObject.Call(method: "TakeDamage" , damageAmount);
			}
		}	
		
		
		// GD.Print("pewwww !!!!!!");
	}
	
	void GetMeshAnim()
	{
		Godot.Collections.Array<Node> meshChildren = mesh.GetChildren();
		Node meshNode = meshChildren[0];
		
		meshAnim = (AnimationPlayer)meshNode.GetNode("AnimationPlayer");
	}
	
}






































































