using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public Vector2 gravDir = Vector2.Down;
	Sprite2D sprite;
	public bool isGrounded = false;
	Vector2 startPos;
	[Export] public int speed = 200;
	public override void _Ready() {
		startPos = Position;
		sprite = GetNode<Sprite2D>("PlayerSprite");
		DisplayServer.WindowSetSize(new(1024,600));
	}
	bool GetKey(Key key) => Input.IsPhysicalKeyPressed(key);
	public override void _PhysicsProcess(double delta) {
		float dt = (float)delta;
		isGrounded = false;
		for (int i = 0; i < GetSlideCollisionCount(); i++) {
			var collider = GetSlideCollision(i);
			if (collider.GetCollider() is not StaticBody2D)
				continue;
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
		if (
			Position.Y > 600
			|| Position.Y < 0
			|| Position.X > 1024
			|| Position.X < 0
		) {
			Position = startPos;
			Velocity = Vector2.Zero;
			gravDir = Vector2.Down;
			isGrounded = false;
		}
		MoveAndSlide();
	}
}
