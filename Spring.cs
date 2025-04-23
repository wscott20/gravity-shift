using Godot;
using System;

public partial class Spring : Area2D
{
	[Export] public float bounce = 800;
	public override void _Ready() {
		BodyEntered += OnBodyEntered;
	}
	void OnBodyEntered(Node node) {
		if (node is Player player) {
			if (player.gravDir == Vector2.Up) {
				player.Velocity = new Vector2(player.Velocity.X, bounce);
			} else if (player.gravDir == Vector2.Right) {
				player.Velocity = new Vector2(bounce, player.Velocity.Y);
			} else if (player.gravDir == Vector2.Left) {
				player.Velocity = new Vector2(-bounce, player.Velocity.Y);
			} else if (player.gravDir == Vector2.Down) {
				player.Velocity = new Vector2(player.Velocity.X, -bounce);
			}
			player.isGrounded = false;
		}
	}
	
}
