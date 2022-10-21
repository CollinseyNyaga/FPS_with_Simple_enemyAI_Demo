using Godot;
using System;

public partial class EnemyAnimationManager : Node
{
    // GAME OBJECTS : 
	Node characterParent;
	
	AnimationPlayer charAnim;
	
	
	// PATHS : 
	string character_parent_path = "../character";
	
	
	// VALUES : 
	
	
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        characterParent = GetNode(character_parent_path);
		
		GetCharAnim();
		
    }

	void GetCharAnim()
	{
		Godot.Collections.Array<Node> characterNodeChildren = characterParent.GetChildren();
		Node character = (Node) characterNodeChildren[0];
		charAnim = (AnimationPlayer)character.GetNode("AnimationPlayer");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(double delta)
//  {
//      
//  }

	public void Run()
	{
		charAnim.Play("run");
	}
	
	public void Idle()
	{
		charAnim.Play("idle");		
	}
	
	public void BeginAttackMode()
	{
		charAnim.Play("whirl_twist");
	}
	
}
















