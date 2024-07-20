using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public enum GameState
{
	Menu,
	Playing,
	Paused,
	GameOver
}



public partial class level_manager : Node2D
{
	[Signal]
	public delegate void GameStateSignalEventHandler(GameState newState);
	public GameState gameState { get; private set; }

	// Debug info
	private debug_display debugDisplay;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		debugDisplay = GetNode<debug_display>("./debug_display");
		UpdateGameState(GameState.Playing);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _Input(InputEvent @event)
    {
      base._Input(@event);
			if (@event.IsActionPressed("toggle_pause")) {
				GameState newState = gameState == GameState.Playing 
					? GameState.Paused 
					: GameState.Playing;
				UpdateGameState(newState);
			}
    }

    public void UpdateGameState(GameState newState)
	{
		gameState = newState;
		EmitSignal(nameof(GameStateSignalEventHandler), Variant.From(gameState));
		debugDisplay.RemoveDebugText("GameState");
		debugDisplay.WriteDebugText("GameState", gameState.ToString());
	}
}