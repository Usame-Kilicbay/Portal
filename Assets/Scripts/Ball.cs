using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(0f,1000f)]
    [SerializeField] private float rollSpeed;

    [Header("Components")]
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private Rigidbody rigidbody;

	[SerializeField] private bool isTocuhedGround;

	private void FixedUpdate()
	{
		if (!isTocuhedGround)
		{
			return;
		}

        Roll();
	}

	private void Roll()
	{
		rigidbody.MoveRotation(Quaternion.AngleAxis(Input.GetAxis("Horizontal") * Time.deltaTime * rollSpeed, Vector3.forward));
		rigidbody.MoveRotation(Quaternion.AngleAxis(Input.GetAxis("Vertical") * Time.deltaTime * rollSpeed, Vector3.right));
	}

	private void OnCollisionEnter(Collision collision)
	{
		isTocuhedGround = true;
	}
}
