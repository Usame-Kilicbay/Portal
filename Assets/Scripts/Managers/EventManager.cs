using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
	// Game
	public UnityAction<Transform, float> BounceBall;

	// UI
	public UnityAction UpdateLevelText;

	// Level
	public Func<int> GetSavedLevelID;
	public UnityAction SaveLevelID;
	public UnityAction LoadLevel;

	// Result
	public UnityAction LevelFailed;
	public UnityAction LevelCompleted;
}
