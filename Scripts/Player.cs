using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private Vector2 velocity = Vector2.Zero;
	private Vector2 direction = Vector2.Zero;
	public float speed = 25;

	private void Read_Input()
	{
		var inputVector = Vector2.Zero;

		// Get player input for movement
		if (Input.IsActionPressed("Up"))
		{
			GD.Print("Up pressed");
			inputVector.Y -= 1;
		}
		if (Input.IsActionPressed("Down"))
		{
			GD.Print("Down pressed");
			inputVector.Y += 1;
		}
		if (Input.IsActionPressed("Left"))
		{
			GD.Print("Left pressed");
			inputVector.X -= 1;
		}
		if (Input.IsActionPressed("Right"))
		{
			GD.Print("Right pressed");
			inputVector.X += 1;
		}

		// Normalize the input vector to ensure consistent speed
		inputVector = inputVector.Normalized();

		// Calculate velocity based on input vector and speed
		velocity = inputVector * speed;

		MoveLocalX(velocity.X);
		MoveLocalY(velocity.Y);
	}

	public override void _PhysicsProcess(double delta)
	{
		Read_Input();
	}
}
