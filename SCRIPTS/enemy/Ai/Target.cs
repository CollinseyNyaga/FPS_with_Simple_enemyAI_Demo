using Godot;
using System;

public partial class Target : Node3D
{
	// GAME OBJECTS : 
	Node parentAiAgent;			// the agent of the ai  
	Node3D targetObject;		// the target spatial node itself. The current node should follow this , keeping an offset
	Node ai;
	CollisionShape3D targetAreaCollisionShape;


	// PATHS : 
	string parent_ai_agent_path = "../../";	
	string ai_path = "../";
	string target_area_collision_shape_path = "Area3D/CollisionShape3D";


	
	// VALUES : 
	Vector3 targetOffset;
	float radius = 20f;				// the radius of the area of the target , which when entered by the actual ai agent
									//  , will report to the ai node that the ai agent has arrived

	
	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        parentAiAgent = GetNode(parent_ai_agent_path);
		ai = GetNode(ai_path);
		targetAreaCollisionShape = (CollisionShape3D)GetNode(target_area_collision_shape_path);
		
		SetRadius();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
    	FollowTarget();
	}

	void SetRadius()
	{
		Godot.Shape3D targetAreaShape = targetAreaCollisionShape.Shape;
		
		CylinderShape3D csH = new CylinderShape3D();
		if(targetAreaShape.GetType()  == csH.GetType())
		{
			csH = (CylinderShape3D)targetAreaShape;
			csH.Radius = radius;
		}
	}

	void SetTargetObject(Node3D t , Vector3 offset)
	{
		// sets the 3d object that the target itself should follow : 
		targetObject = t;
		targetOffset = offset;
	}
	
	void FollowTarget()
	{
		// follows the target game object :
		Transform3D newT = this.GlobalTransform;
		newT.origin = targetObject.GlobalTransform.origin - targetOffset;
		
		this.GlobalTransform = newT;
	}
	
	void BodyEnteredArea(Node body)
	{
		if(body == parentAiAgent)
		{
			// when the parent agent enters the target area , it means that they have arrived their destination .
			ai.Call("TargetAreaArrived");
		}
	}
	
	void BodyExitedArea(Node body)
	{
		if(body == parentAiAgent)
		{
			// when the parent agent exits the target area , report that the destination has changed :
			ai.Call("TargetChanged");
		}
	}
}












































