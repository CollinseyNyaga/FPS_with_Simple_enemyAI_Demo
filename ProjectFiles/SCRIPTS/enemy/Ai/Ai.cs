using Godot;
using System;

public partial class Ai : Node3D
{
    // GAME OBJECTS : 
	Node parentAiAgent;
	Node3D player;
	Node3D target;					// this spatial node aligns its position to the target game object
	Node locomotion;
	
	
	
	// PATHS : 
	string target_path = "target";
	string player_path = "../../../Player";
	string locomotion_path = "locomotion";
	string parent_ai_agent_path = "../";
	
	
	// VALUES : 
	
	
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
		// get objects : 
		player = (Node3D)GetNode(player_path);
        target = (Node3D)GetNode(target_path);
		locomotion = GetNode(locomotion_path);
		parentAiAgent = GetNode(parent_ai_agent_path);
		
		
		// 
		SetPlayerAsTarget();
		MoveTowardsTarget();
		
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(double delta)
//  {
//      
//  }

	void SetPlayerAsTarget()
	{
		Vector3 offset = new Vector3(0,0,0);				// offset of the target to the ai agent
		
		target.Call("SetTargetObject" , player , offset);
	}
	
	void MoveTowardsTarget()
	{
		locomotion.Call("StartMoving");
	}
	
	public void TargetAreaArrived()
	{
		// called from the target node , to report that the ai agent has got to the target area : 
		// its possible to stop the ai agent , or make it attack from here , by calling its methods : 
		
		parentAiAgent.Call("Attack");
		//GD.Print("Arrived");
	}
	
	public void TargetChanged()
	{
		// called from the target node , to report that the target has changed and the agent should begin moving  : 
		MoveTowardsTarget();
	}
	
	
}




















































