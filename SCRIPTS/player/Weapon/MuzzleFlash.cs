using Godot;
using System;

public partial class MuzzleFlash : Node3D
{
	// GAME OBJECTS : 
   	AnimationPlayer anim;
	
	
	// PATHS : 
	string anim_path = "AnimationPlayer";
	
	
	// VALUES : 
	
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        anim = (AnimationPlayer)GetNode(anim_path);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(double delta)
//  {
//      
//  }

	public void Flash()
	{
		// randomize flash rotation : 
		Vector3 newRot = this.Rotation;
		newRot.z = newRot.z + Godot.Mathf.DegToRad(15f);
		this.Rotation = newRot;
	
		// flash animation : 
		anim.Play(name: "flash");
	}
}
















