using UnityEngine;

public class ElectricTrap : Trap
{
	private void OnTriggerEnter(Collider other)
	{
		GameManager.GameState = GameStates.LevelFailed;
	}
}
