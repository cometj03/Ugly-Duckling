using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameObject floor;
	public GameObject moon;
	public GameObject background;
	public GameObject mountain;
	public GameObject mountaincloud;

	public Vector3 cameraTargetVector;
	private Camera maincamera;
	private bool isCloudUp = true;
	private float smoothCameraSpeed, speed;

	private float bgOffsetX, moonOffsetX, mtOffsetX;

	private void Start()
	{
		maincamera = gameObject.GetComponent<Camera>();
		cameraTargetVector = maincamera.transform.position;
		speed = 0.01f;
		smoothCameraSpeed = 0.025f;

		bgOffsetX = background.transform.position.x - cameraTargetVector.x;
		moonOffsetX = moon.transform.position.x - cameraTargetVector.x;
		mtOffsetX = mountain.transform.position.x - cameraTargetVector.x;
	}

	private void FixedUpdate()
	{
		// 카메라 이동
		maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, cameraTargetVector, smoothCameraSpeed);
		
		// 배경 오브젝트 이동
		MoveBgObject(background, bgOffsetX, 0.95f);
		MoveBgObject(moon, moonOffsetX, 0.93f);
		//MoveBgObject(mountain, mtOffsetX, 0.7f);
		
		// floor 반복
		if (maincamera.transform.position.x - 4.8f >= floor.transform.position.x)
			floor.transform.position += Vector3.right * 9.6f;
		//if (maincamera.transform.position.x - 12f >= mountain.transform.position.x)
		//	background.transform.position += Vector3.right * 24f;

		
		if (mountaincloud.transform.position.y > -1f)
			isCloudUp = false;
		else if (mountaincloud.transform.position.y < -1.3f)
			isCloudUp = true;
		
		float cloudDeltaY = isCloudUp ? 0.2f : -0.2f;

		mountain.transform.position += Vector3.right * (speed * 0.7f);
		mountaincloud.transform.position += new Vector3(0, cloudDeltaY * (speed * 0.7f));
		
		cameraTargetVector += Vector3.right * speed;
	}

	private void MoveBgObject(GameObject gameObject, float offset, float ratio)
	{
		Vector3 pos = gameObject.transform.position;
		pos.x = Mathf.Lerp(pos.x, cameraTargetVector.x * ratio + offset, smoothCameraSpeed);
		gameObject.transform.position = pos;
	}
}
