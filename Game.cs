using Godot;
using System;

public partial class Game : Node2D {
	RigidBody2D player;
	[Export] public int speed = 200;
	public override void _Ready() {
		player = GetNode<RigidBody2D>("Player");
	}
	public override void _Process(double delta) {
		float dt = (float)delta;
		if (Input.IsPhysicalKeyPressed(Key.Up))
			player.LinearVelocity = new(player.LinearVelocity.X,-1);
		if (Input.IsPhysicalKeyPressed(Key.Down))
			player.LinearVelocity = new(player.LinearVelocity.X,1);
		if (Input.IsPhysicalKeyPressed(Key.Right))
			player.LinearVelocity = new(1,player.LinearVelocity.Y);
		if (Input.IsPhysicalKeyPressed(Key.Left))
			player.LinearVelocity = new(-1,player.LinearVelocity.Y);
	}
}
