using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public CameraValue cameraValue;

	private Transform _birdTransform;
	private Camera maincamera;
	private float speed;

	private void Awake()
	{
		maincamera = gameObject.GetComponent<Camera>();
		
		cameraValue.cameraTarget = cameraValue.backgroundTarget = maincamera.transform.position;	// Initialized cameraTarget
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

		if (PlayerData.Instance.currentState == GameState.CONTINUE)
		{
			cameraValue.cameraTarget += Vector3.right * speed;
			cameraValue.backgroundTarget += Vector3.right * speed;


			// 카메라 뒤로 물러남
			if (_birdTransform.position.x - 3f > cameraValue.cameraTarget.x)
			{
				var position = _birdTransform.position;
				cameraValue.cameraTarget.x = position.x + 1;
				cameraValue.backgroundTarget.x = position.x + 1;
			}

			// 오리가 위로 올라가면 카메라도 위로
			if (_birdTransform.position.y > 0.5f)
				cameraValue.cameraTarget.y = 1.2f;
			else
				cameraValue.cameraTarget.y = 0;
		}
	}
}
