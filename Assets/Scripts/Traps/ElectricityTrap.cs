using UnityEngine;

public class ElectricityTrap : Trap
{
	private void OnTriggerEnter(Collider other)
	{
		GameManager.GameState = GameStates.LevelFailed;
	}
}
