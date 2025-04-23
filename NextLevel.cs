using Godot;
using System;

public partial class NextLevel : Area2D
{
	static int level = 1;
	public override void _Ready() {
		BodyEntered += OnBodyEntered;
	}
	void OnBodyEntered(Node node) {
		if (node is Player)
			CallDeferred(nameof(LoadNextLevel));
	}
	void LoadNextLevel() {
		string nextLevel = $"res://level{level+1}.tscn";
		if (FileAccess.FileExists(nextLevel)) {
			level++;
			//GD.Print($"Loading {nextLevel}");
			GetTree().ChangeSceneToFile(nextLevel);
		}
	}
}
