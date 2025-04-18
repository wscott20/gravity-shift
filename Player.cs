using Godot;
using System;

public partial class Player : RigidBody2D
{
	[Export] public int speed = 200;
	//public override void _Ready() {
	//	
	//}
	public override void _Process(double delta) {
		float dt = (float)delta;
		if (Input.IsPhysicalKeyPressed(Key.Up))
			LinearVelocity = new(LinearVelocity.X,-speed);
		if (Input.IsPhysicalKeyPressed(Key.Down))
			LinearVelocity = new(LinearVelocity.X,speed);
		if (Input.IsPhysicalKeyPressed(Key.Right))
			LinearVelocity = new(speed,LinearVelocity.Y);
		if (Input.IsPhysicalKeyPressed(Key.Left))
			LinearVelocity = new(-speed,LinearVelocity.Y);
	}
}
