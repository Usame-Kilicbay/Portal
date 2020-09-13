using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
	[Range(0f, 1000f)]
	[SerializeField] private float rotationSpeed;

	[Header("Limit")]
	[SerializeField] private float minRotation;
	[SerializeField] private float maxRotation;

	[SerializeField] private Transform parentTransform;

	private void Update()
	{
		if (GameManager.GameState != GameStates.GameStarted)
		{
			return;
		}

		if (Input.GetMouseButton(0))
		{
			RotatePlatform();
			RotateParent();
		}
	}

	private void RotatePlatform()
	{
		float dir = EulerToRotation(transform.localEulerAngles.x);

		float rotX = Input.GetAxis("Mouse X") * Mathf.Deg2Rad * rotationSpeed;

		//if (dir < minRotation && rotX < 0)
		//{
		//	transform.localEulerAngles = Vector3.right * minRotation;
		//	return;
		//}

		//if (dir > maxRotation && rotX > 0)
		//{
		//	transform.localEulerAngles = Vector3.right * maxRotation;
		//	return;
		//}

		transform.Rotate(Vector3.right * rotX * Time.deltaTime * rotationSpeed);

		Vector3 eulerAngles = transform.localEulerAngles;
		eulerAngles.x = Mathf.Clamp(EulerToRotation(transform.localEulerAngles.x), minRotation, maxRotation);

		transform.localEulerAngles = eulerAngles;
	}

	private void RotateParent()
	{
		float dir = EulerToRotation(parentTransform.localEulerAngles.z);

		float rotZ = Input.GetAxis("Mouse Y") * Mathf.Deg2Rad * rotationSpeed;

		//if (dir < minRotation && rotZ < 0)
		//{
		//	parentTransform.localEulerAngles = Vector3.forward * minRotation;
		//	return;
		//}

		//if (dir > maxRotation && rotZ > 0)
		//{
		//	parentTransform.localEulerAngles = Vector3.forward * maxRotation;
		//	return;
		//}

		parentTransform.Rotate(Vector3.forward * rotZ * Time.deltaTime * rotationSpeed);

		Vector3 eulerAngles = parentTransform.localEulerAngles;
		eulerAngles.z = Mathf.Clamp(EulerToRotation(parentTransform.localEulerAngles.z), minRotation, maxRotation);

		parentTransform.localEulerAngles = eulerAngles;
	}

	private float EulerToRotation(float value)
	{
		if (value > 180)
		{
			return value - 360f;
		}
		else if (value < -180)
		{
			return value + 360f;
		}
		else
		{
			return value;
		}
	}
}
