using Godot;
using System;

public partial class Throwable : Node3D
{
	// GAME OBJECTS : 
	Node animationsManager;
	PackedScene grenadeScene;
	Node throwablesParent;
	Node3D spawnPoint;
	Node3D player;
	Node currentThrowable;
	
	
	
	// PATHS : 
	string animations_manager_path = "../../animationsManager";
	string grenade_scene_path = "res://RESOURCES/scenes/player/grenadeScene.tscn";
	string throwables_parent_path = "../../../THROWABLES";
	string spawnpoint_path = "spawnpoint";
	string player_path = "../../";
	string player_cam_path = "../../cam";
	
	
	// VALUES : 
	int grenadeCount = 30;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animationsManager = GetNode(animations_manager_path);
		grenadeScene = (PackedScene)Godot.ResourceLoader.Load(grenade_scene_path);
		spawnPoint = (Node3D)GetNode(spawnpoint_path);
		throwablesParent = GetNode(throwables_parent_path);
		player = (Node3D)GetNode(player_path);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CheckKeyBoardInputs();
	}
	
	void CheckKeyBoardInputs()
	{
		if(Input.IsActionJustReleased("playerGrenade"))
		{
			Throw();
		}
		
		if(Input.IsActionJustPressed("playerGrenade"))
		{
			Hold();
		}
	}
	
	void Hold()
	{
		if(grenadeCount > 0)
		{
			// play holding grenade animation : 
			animationsManager.Call("HoldGrenade");
			
			// spawn the grenade , initialize it with values , but dont launch it : 
			SpawnGrenade();
			
			currentThrowable.Call(method: "InitializeValues" , spawnPoint , player);
		}
	}
	
	void Throw()
	{
		if(grenadeCount > 0)
		{
			// play throw animation : 
			animationsManager.Call("ThrowGrenade");
			
			grenadeCount = grenadeCount - 1;
			
			// throw the grenade :
			currentThrowable.Call(method: "LaunchGrenadeRigidBody");
		}
	}
	
	void SpawnGrenade()
	{
		Node grenadeNode = grenadeScene.Instantiate();
		throwablesParent.AddChild(grenadeNode);
		
		currentThrowable = grenadeNode;
	}
	
}


















































