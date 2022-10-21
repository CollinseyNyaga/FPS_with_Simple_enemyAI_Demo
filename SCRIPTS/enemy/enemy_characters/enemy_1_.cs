using Godot;
using System;

public partial class enemy_1_ : Node3D
{
	// GAME OBJECTS : 
    AnimationPlayer anim;
	Node3D whirl;
	Node3D am;


	// PATHS : 
	string anim_path = "AnimationPlayer";
	string whirl_path = "whirl";
	string am_path = "Armature";
	
	
	// VALUES : 
	
	
	
	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        anim = (AnimationPlayer) GetNode(anim_path);
		whirl = (Node3D)GetNode(whirl_path);
		
		am = (Node3D)GetNode(am_path);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(double delta)
//  {
//      
//  }

	public void StartWhirlAttack()
	{
		// when player starts the whirl attack , the whirl pose of the player is played : 
		anim.Play("whirl");
	}
	
	public void HideWhirl()
	{
		// called mainly from the animation timeline , to hide the whirl from being rendered .
		whirl.Visible = false;
	}
	
	public void ResetRotation()
	{
		// reset the rotation of the armature , called mainly from animation timeline : 
		am.Rotation = new Vector3();
	}
}


























