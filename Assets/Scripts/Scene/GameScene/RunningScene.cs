using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningScene : MonoBehaviour
{
	public GameObject floor;
	public GameObject moon;
	public GameObject background;
	public GameObject mountain;
	public GameObject mountaincloud;
	public Camera maincamera;

	public float speed = 0.1f;

	public Vector3 cameraTargetVector;

	private bool isCloudUp = true;

	private void Start()
	{
		cameraTargetVector = maincamera.transform.position;
	}

	private void FixedUpdate()
	{
		// 배경 오브젝트 이동
		maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, cameraTargetVector, Time.deltaTime);
		background.transform.position = Vector3.Lerp(background.transform.position, cameraTargetVector + new Vector3(3, 0, 10), Time.deltaTime);
		moon.transform.position = Vector3.Lerp(moon.transform.position, cameraTargetVector * 0.9f + new Vector3(3, 0.6f, 10), Time.deltaTime);
		
		// floor 생성
		if (maincamera.transform.position.x - 4.8f >= floor.transform.position.x)
		{
			floor.transform.position += new Vector3(9.6f, 0, 0);
		}

		if (mountaincloud.transform.position.y > -1f)
			isCloudUp = false;
		else if (mountaincloud.transform.position.y < -1.3f)
			isCloudUp = true;
		
		Vector3 cloudVec = isCloudUp ? new Vector3(1, 0.2f, 0) : new Vector3(1, -0.2f, 0);

		mountain.transform.position += Vector3.right * (speed * 0.7f);
		mountaincloud.transform.position += cloudVec * (speed * 0.7f);
		
		cameraTargetVector += Vector3.right * speed;
	}
}
