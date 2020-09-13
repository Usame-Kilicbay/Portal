using UnityEngine;

public class BouncerTrap : Trap
{
	private void OnCollisionEnter(Collision collision)
	{
		EventManager.Instance.BounceBall(transform, bounceForce);
	}
}
