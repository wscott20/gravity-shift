using Godot;
using System;

public partial class Player : CharacterBody2D
{
	Vector2 gravDir = Vector2.Down;
	[Export] public int speed = 200;
	// public override void _Ready() {
	// }
	bool GetKey(Key key) => Input.IsPhysicalKeyPressed(key);
    public override void _PhysicsProcess(double delta) {
		float dt = (float)delta;
		Vector2 vel = Velocity;
		if (gravDir == Vector2.Up || gravDir == Vector2.Down) {
			vel.X = 0;
			if (GetKey(Key.Left))
				vel.X -= speed;
			if (GetKey(Key.Right))
				vel.X += speed;
		}
		if (gravDir == Vector2.Up || gravDir == Vector2.Down) {
			vel.Y = 0;
			if (GetKey(Key.Up))
				vel.Y -= speed;
			if (GetKey(Key.Down))
				vel.Y += speed;
		}
		vel += gravDir * 9.8f * dt;
		for (int i = 0; i < GetSlideCollisionCount(); i++) {
			var collider = GetSlideCollision(i);
			Vector2 norm = collider.GetNormal();
		}
		Velocity = vel;
		MoveAndSlide();
	}
}
