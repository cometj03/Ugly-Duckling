using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameManager _gameManager;
	public CameraValue cameraValue;

	private Transform _birdTransform;
	private Camera maincamera;
	private float speed;

	private void Awake()
	{
		maincamera = gameObject.GetComponent<Camera>();
		
		cameraValue.cameraTarget = maincamera.transform.position;	// Initialized cameraTarget
		speed = 0.01f;
	}

	private void Start()
	{
		if (GameObject.Find("bird") != null)
			_birdTransform = GameObject.Find("bird").transform;
	}

	private void FixedUpdate()
	{
		// 카메라 이동
		maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, cameraValue.cameraTarget, CameraValue.SmoothSpeed);
		if (_gameManager.currentState == GameManager.GameState.CONTINUE)
			cameraValue.cameraTarget += Vector3.right * speed;
		
		// 카메라 뒤로 물러남
		if (_birdTransform.position.x - 3f > cameraValue.cameraTarget.x && _gameManager.currentState == GameManager.GameState.CONTINUE)
			cameraValue.cameraTarget = new Vector3(_birdTransform.position.x + 1f, cameraValue.cameraTarget.y, -10);
		
	}
}
