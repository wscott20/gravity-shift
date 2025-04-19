using Godot;
using System;

public partial class Player : CharacterBody2D
{
	Vector2 gravDir = Vector2.Down;
	Sprite2D sprite;
	bool isGrounded = false;
	[Export] public int speed = 200;
	public override void _Ready() {
		sprite = GetNode<Sprite2D>("PlayerSprite");
	}
	bool GetKey(Key key) => Input.IsPhysicalKeyPressed(key);
	public override void _PhysicsProcess(double delta) {
		float dt = (float)delta;
		isGrounded = false;
		for (int i = 0; i < GetSlideCollisionCount(); i++) {
			var collider = GetSlideCollision(i);
			Vector2 norm = collider.GetNormal();
			gravDir = -norm;
			isGrounded = true;
		}
		if (gravDir == Vector2.Up)
			sprite.Rotation = Mathf.Pi;
		if (gravDir == Vector2.Down)
			sprite.Rotation = 0;
		if (gravDir == Vector2.Left)
			sprite.Rotation = Mathf.Pi*.5f;
		if (gravDir == Vector2.Right)
			sprite.Rotation = Mathf.Pi*1.5f;
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
			vel -= gravDir * 400;// * jumpForce * dt;
			isGrounded = false;
		}
		vel += gravDir * 20;
		Velocity = vel;
		MoveAndSlide();
	}
}
