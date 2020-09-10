using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
	[Range(0f,1000f)]
	[SerializeField] private float rotationSpeed;

	[Header("Limit")]
	[SerializeField] private float minRotation;
	[SerializeField] private float maxRotation;

	[SerializeField] private Transform parentTransform;

	private void OnMouseDrag()
	{
		RotatePlatform();
		RotateParent();
	}

	private void RotatePlatform()
	{
		float dir = EulerToRotation(transform.localEulerAngles.x);

		float rotX = Input.GetAxis("Mouse X") * Mathf.Deg2Rad * rotationSpeed;
		
		if (dir < minRotation && rotX < 0)
		{
			transform.localEulerAngles = Vector3.right * minRotation;
			return;
		}

		if (dir > maxRotation && rotX > 0)
		{
			transform.localEulerAngles = Vector3.right * maxRotation;
			return;
		}

		transform.Rotate(Vector3.Lerp(transform.localEulerAngles, Vector3.right * rotX * Time.deltaTime, rotationSpeed));
	}

	private void RotateParent() 
	{
		float dir = EulerToRotation(parentTransform.localEulerAngles.z);

		float rotZ = Input.GetAxis("Mouse Y") * Mathf.Deg2Rad * rotationSpeed;

		if (dir < minRotation && rotZ < 0)
		{
			parentTransform.localEulerAngles = Vector3.forward * minRotation;
			return;
		}

		if (dir > maxRotation && rotZ > 0)
		{
			parentTransform.localEulerAngles = Vector3.forward * maxRotation;
			return;
		}

		parentTransform.Rotate(Vector3.Lerp(parentTransform.localEulerAngles, Vector3.forward * rotZ * Time.deltaTime, rotationSpeed));
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
