using UnityEngine;

public class Portal : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		EventManager.Instance.LevelCompleted();
	}
}
