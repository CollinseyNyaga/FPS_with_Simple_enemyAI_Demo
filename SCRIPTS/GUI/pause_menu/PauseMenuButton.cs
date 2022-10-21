using Godot;
using System;

public partial class PauseMenuButton : Control
{
	// GAME OBJECTS : 
	Control back;
	Label buttonLabel;
	Node pauseMenu;
	
	
	// PATHS : 
	string back_path = "ColorRect";
	string button_label_path = "Label";
	string pause_menu_path = "../../";
	
	
	// VALUES : 
	bool hovered = false;
	float targetBackSizeX = 0;
	Vector2 originalBackSize;
	
	Color labelHoverColor;
	Color labelNormalColor;
	
	string originalName;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		back = (Control)GetNode(back_path);
		originalBackSize = back.Size;
		buttonLabel = (Label)GetNode(button_label_path);
		pauseMenu = GetNode(pause_menu_path);

		originalName = this.Name;
		
		labelHoverColor = new Color(1,1,1,1);					// rgba
		labelNormalColor = new Color(0.67f,0.27f,0f,1f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		SetName();
		InterpolateBackSizeX();
	}
	
	public void GuiInput(InputEvent ev)
	{
		// called when a gui input signal is emitted : 
		InputEventMouseButton mb = new InputEventMouseButton();
		if(ev.GetType() == mb.GetType())
		{
			mb = (InputEventMouseButton)ev;
			
			if(mb.ButtonIndex == Godot.MouseButton.Left && mb.Pressed == false)
			{
				ButtonClicked();
			}
		}
	}
	
	public void ButtonHovered()
	{
		hovered = true;
		SetLabelColor(labelHoverColor);
	}
	
	public void MouseExited()
	{
		hovered = false;
		SetLabelColor(labelNormalColor);
		back.Size = 	originalBackSize;
	}
	
	void InterpolateBackSizeX()
	{
		// animates the control size.x of the back control : 
		if(hovered == true)
		{
			if(back.Size.x > 0.1f)
			{
				Vector2 newSize = back.Size;
				newSize.x = newSize.x - 7f;
				back.Size = newSize;
			}
			else
			{
				// round off to 0 :
				Vector2 newSize = back.Size;
				newSize.x = 0;
				back.Size = newSize;
				
				// 
			}
		}
	}
	
	void SetLabelColor(Color c)
	{
		buttonLabel.AddThemeColorOverride("font_color" , c);
	}
	
	public void ButtonClicked()
	{
		// : 
	
	
		// action :
		pauseMenu.Call(method: "Action" , args: this.Name);
	}
	
	void SetName()
	{
		// for some wierd reason , the name of the current button changes to wierd symbols , causing it
		// to be inaccessible. This corrects it
		this.Name = originalName;
	}
}






