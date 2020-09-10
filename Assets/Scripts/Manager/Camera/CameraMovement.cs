using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameManager _gameManager;
	public CameraValue cameraValue;
	private Camera maincamera;
	private float speed;

	private void Awake()
	{
		maincamera = gameObject.GetComponent<Camera>();
		
		cameraValue.cameraTarget = maincamera.transform.position;	// Initialized cameraTarget
		speed = 0.01f;
	}

	private void FixedUpdate()
	{
		// 카메라 이동
		maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, cameraValue.cameraTarget, CameraValue.SmoothSpeed);
		if (_gameManager.currentState == GameManager.GameState.GameContinue)
			cameraValue.cameraTarget += Vector3.right * speed;
	}
}
