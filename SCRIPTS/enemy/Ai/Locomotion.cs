using Godot;
using System;

public partial class Locomotion : Node
{
    // GAME OBJECTS : 
	Node ai;
	Node parentAiAgent = new Node();
	Node3D target;
	
	
	// PATHS : 
	string ai_path = "../../";
	string target_path = "../target";
	
	
	// VALUES : 
	
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {	
		ai = GetNode(ai_path);
        parentAiAgent = GetNode(ai_path);
		
		target = (Node3D)GetNode(target_path);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	    
	}
	
	public void StartMoving()
	{
		// set look target , whereby the player looks at the target , and moves according to the z basis: 
		parentAiAgent.Call(method: "SetLookTarget" , target);
		
		// move to the target : 
		parentAiAgent.Call(method: "StartMove");
	}
	
	void Stop()
	{
		parentAiAgent.Call(method: "Stop");	
	}
}




















