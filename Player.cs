using Godot;
using System;

public partial class Player : RigidBody2D
{
	[Export] public int speed = 200;
	bool isGrounded = false;
	public override void _Ready() {
		ContactMonitor = true;
		MaxContactsReported = 10;
	}
	bool GetKey(Key key) => Input.IsPhysicalKeyPressed(key);
	public override void _Process(double delta) {
		float dt = (float)delta;
		// if (GetKey(Key.P))
		// 	Console.WriteLine(MaxContactsReported);
		if (GetKey(Key.Up))
			LinearVelocity = new(LinearVelocity.X,-speed);
		if (GetKey(Key.Down))
			LinearVelocity = new(LinearVelocity.X,speed);
		if (GetKey(Key.Right))
			LinearVelocity = new(speed,LinearVelocity.Y);
		if (GetKey(Key.Left))
			LinearVelocity = new(-speed,LinearVelocity.Y);
	}
	public override void _PhysicsProcess(double delta) {
		base._PhysicsProcess(delta);
		//set isGrounded false
		foreach (var obj in GetCollidingBodies()) {
			//get collision normal
			//if normal on top set isGrounded to true
		}
	}
}
