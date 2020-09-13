using UnityEngine;

public class Portal : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		GameManager.GameState = GameStates.LevelCompleted;
	}
}
