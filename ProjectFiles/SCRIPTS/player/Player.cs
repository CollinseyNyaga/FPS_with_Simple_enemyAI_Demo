using Godot;
using System;

public partial class Player : CharacterBody3D
{
    // GAME OBJECTS : 
	Node3D cam;
	Node animationsManager;
	
	
	// PATHS : 
	string cam_path = "cam";
	string animations_manager_path = "animationsManager";
	
	// VALUES : 
	int Health = 100;
	float mouseSens = 0.5f;
	float maxLookCamX = 80f;
	
	float speed = 30f;
	
	Vector3 up_direction;
	
	float jumpHeight = 5f;
	float jumpGravity = 60f;
	Vector3 targetJumpPos;
	
	float gravity = -9.8f;
	float gravityAcceleration = 2f;
	float fallGravity = -50f;
	
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
		cam = (Node3D)GetNode(cam_path);
		animationsManager = GetNode(animations_manager_path);
		
		up_direction = new Vector3(0,1,0);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(double delta)
//  {
//      
//  }
	
	public override void _PhysicsProcess(double delta)
	{
		AddForces();
		CheckJumpHeight();
	}
	
	void AddForces()
	{
		AddGravity();
		MoveAndSlide();			
	}
	
	void AddGravity()
	{
		Vector3 newVelocity = this.Velocity;
		newVelocity.y = gravity;
		
		SetVelocity(newVelocity);
	}
	
	public void Move(int directionIndex)
	{
		// GD.Print(directionIndex);
		
		Vector3 directionZ = this.GlobalTransform.basis.z;
		Vector3 directionX = this.GlobalTransform.basis.x;
		
		Vector3 newVelocity = this.Velocity;
		
		
		switch(directionIndex)
		{
			case 0: 
				newVelocity = -speed * directionZ;
			break;
			
			case 1: 
				newVelocity = speed * directionZ;			
			break;
			
			case 2: 
				newVelocity = -speed * directionX;
			break;
			
			case 3: 
				newVelocity = speed * directionX;
			break;
			
			default : break;			
		}	
		
		SetVelocity(newVelocity);
		
		if(this.IsOnFloor() == true)
		{
			// play running animation : 
			animationsManager.Call("Run");
		}
		
		// GD.Print(Velocity);
		
	}
	
	public void Stop()
	{
		Vector3 newVelocity = this.Velocity;
		newVelocity.z = 0;
		newVelocity.x = 0;

		SetVelocity(newVelocity);
		
		// stop running animation : 
		animationsManager.Call(method: "StopRun");
	}
	
	public void Look(Vector2 mouseRel)
	{
		// LOOK SIDEWAYS : 
		Vector3 newRot = this.Rotation;
		newRot.y = newRot.y - (mouseRel.x * mouseSens / 200);
		
		this.Rotation = newRot;
		
		// LOOK UP AND DOWN :
		Vector3 newCamRot = cam.Rotation;
		newCamRot.x = newCamRot.x - (mouseSens * mouseRel.y / 100);
		newCamRot.x = Mathf.Clamp(value: newCamRot.x , min: -Mathf.DegToRad(maxLookCamX) , max: Mathf.DegToRad(maxLookCamX));
		cam.Rotation = newCamRot;
		
	}
	
	public void Jump()
	{
		// set the force that makes the player go up
		gravity = jumpGravity;
		
		// set target jump position that the player should attain , so that they begin falling : 
		targetJumpPos = this.GlobalTransform.origin;
		targetJumpPos.y = targetJumpPos.y + jumpHeight;
		
		// stop the run animation : 
		animationsManager.Call(method: "StopRun");
		
	}
	
	void CheckJumpHeight()
	{
		Vector3 currentPlayerPos = this.GlobalTransform.origin;
		
		if(currentPlayerPos.y >= (targetJumpPos.y - 0.01f))
		{
			// here , player has attained maximum height , and should begin coming down : 
			
			
			if(gravity > fallGravity)
			{	
				// smoothly interpolate the current gravity to the required one , by reducing it with acceleration due to gravity
				gravity = gravity - gravityAcceleration;
			}
		}
	}
	
	public void TakeDamage(int value)
	{
		Health = Health - value;
		// GD.Print($"Ouuuu !!!!! {Health}");
	}
	
	void CheckDamage()
	{
		if(Health <= 0)
		{
			// GD.Print("player ended !!");
		}
	}
	
	
}




























































































