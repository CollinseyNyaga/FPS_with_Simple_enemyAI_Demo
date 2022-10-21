using Godot;
using System;

public partial class DamageEffect : Node3D
{
    // GAME OBJECTS: 
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

	public void PositionSelf(Vector3 spawnPoint)
	{
		Transform3D newT = this.GlobalTransform;
		newT.origin = spawnPoint;
		this.GlobalTransform = newT;
	}
	
	public void PlayEffect()
	{
		anim.Play(name: "damage_animation");
	}
}


















