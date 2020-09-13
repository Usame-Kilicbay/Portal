using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(0f,1000f)]
    [SerializeField] private float rollSpeed;

    [Header("Components")]
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private Rigidbody rigidbody;

	[SerializeField] private bool isTocuhedGround;

	private void OnEnable()
	{
		Subscribe();
	}

	private void OnDisable()
	{
		GameManager.QuitControl(Unsubscribe);
	}

	#region Event Subscribe/Unsubscribe

	private void Subscribe()
	{
		EventManager.Instance.BounceBall += Bounce;
		EventManager.Instance.LevelCompleted += StopBall;
		EventManager.Instance.LevelFailed += StopBall;
	}

	private void Unsubscribe()
	{
		EventManager.Instance.BounceBall -= Bounce;
		EventManager.Instance.LevelCompleted -= StopBall;
		EventManager.Instance.LevelFailed -= StopBall;
	}

	#endregion

	private void FixedUpdate()
	{
		if (!isTocuhedGround && GameManager.GameState != GameStates.GameStarted)
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

	private void Bounce(Transform bouncerTrapTransform, float bouncePower)
	{
		rigidbody.AddForce(-bouncerTrapTransform.up * bouncePower, ForceMode.Impulse);
	}

	private void StopBall() 
	{
		rigidbody.isKinematic = true;
		sphereCollider.enabled = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!isTocuhedGround)
		{
			isTocuhedGround = true;
		}
	}
}
