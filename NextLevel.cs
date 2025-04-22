using Godot;
using System;

public partial class NextLevel : Area2D
{
	static int level = 1;
	public override void _Ready() {
		BodyEntered += OnBodyEntered;
	}
	void OnBodyEntered(Node node) {
		if (node is Player) {
			level++;
			GD.Print($"Level {level}");
			GetTree().ChangeSceneToFile($"res://level{level}.tscn");
		}
	}
}
