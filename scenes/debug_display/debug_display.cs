using Godot;
using System;
using System.Collections.Generic;


public partial class debug_display : Node {

	private SortedDictionary<string, string> debugDisplays;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		debugDisplays = new SortedDictionary<string, string>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	// Write a key-value pair to the debug text display, "key: value"
	public void WriteDebugText(string key, string value)
	{
		debugDisplays.Add(key, value);
    string displayedText = "";
		foreach (KeyValuePair<string, string> entry in debugDisplays)
		{
			displayedText += entry.Key + ": " + entry.Value + "\n";
		}

		GetNode<RichTextLabel>("debug_text").Text = displayedText;
	}

	// Remove debug text from the display window by key
	public void RemoveDebugText(string key)
	{
		debugDisplays.Remove(key);
	}
}
