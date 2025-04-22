using Godot;
using System;

public partial class NextLevel : Area2D
{
	public override void _Ready() {
		BodyEntered += OnBodyEntered;
	}
	void OnBodyEntered(Node node) {
		if (node is Player) {
			GetTree().ChangeSceneToFile("res://level2.tscn");
		}
	}
}
