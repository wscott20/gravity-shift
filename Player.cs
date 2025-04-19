using Godot;
using System;

public partial class Player : CharacterBody2D
{
	Vector2 gravDir = Vector2.Down;
	bool isGrounded = false;
	[Export] public int speed = 200;
	[Export] public int jumpForce = 400;
	// public override void _Ready() {
	// }
	bool GetKey(Key key) => Input.IsPhysicalKeyPressed(key);
	public override void _PhysicsProcess(double delta) {
		float dt = (float)delta;
		isGrounded = false;
		for (int i = 0; i < GetSlideCollisionCount(); i++) {
			var collider = GetSlideCollision(i);
			Vector2 norm = collider.GetNormal();
			if (-norm == gravDir) {
				isGrounded = true;
				break;
			}
		}
		Vector2 vel = Velocity;
		if (gravDir == Vector2.Up || gravDir == Vector2.Down) {
			if (isGrounded)
				vel.Y = 0;
			vel.X = 0;
			if (GetKey(Key.Left))
				vel.X -= speed;
			if (GetKey(Key.Right))
				vel.X += speed;
		}
		if (gravDir == Vector2.Right || gravDir == Vector2.Left) {
			if (isGrounded)
				vel.X = 0;
			vel.Y = 0;
			if (GetKey(Key.Up))
				vel.Y -= speed;
			if (GetKey(Key.Down))
				vel.Y += speed;
		}
		if (GetKey(Key.Space) && isGrounded) {
			vel -= gravDir * jumpForce * dt;
			isGrounded = false;
		}
		vel += gravDir * 100 * dt;
		Velocity = vel;
		MoveAndSlide();
	}
}
