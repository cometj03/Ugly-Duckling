using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Vector3 cameraTargetVector;
	private Camera maincamera;
	private float speed;
	private const float smoothCameraSpeed = 0.025f;

	private void Awake()
	{
		maincamera = gameObject.GetComponent<Camera>();
		cameraTargetVector = maincamera.transform.position;
		speed = 0.01f;
	}

	private void FixedUpdate()
	{
		// 카메라 이동
		maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, cameraTargetVector, smoothCameraSpeed);
		cameraTargetVector += Vector3.right * speed;
	}
}
