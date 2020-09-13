using UnityEngine;

public class Trap : MonoBehaviour
{
	public enum TrapType
	{
		Bouncer,
		ElectricityField
	}

	public TrapType trapType;

	[SerializeField] protected Collider collider;

	[Range(0f, 20)]
	[SerializeField] protected float bounceForce;
}
