using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningScene : MonoBehaviour
{
	public GameObject bird;
	public GameObject floor;
	public GameObject moon;
	public GameObject background;
	public GameObject mountain;
	public GameObject mountaincloud;
	public Camera maincamera;

	public float speed = 0.1f;

	public bool can_jump = true;
	private bool isCloudUp = true;

	// bird property
	private static readonly int IsWalk = Animator.StringToHash("is_walk");
	private Transform _birdTransform;
	private Animator _birdAnimator;
	private SpriteRenderer _birdSpriteRenderer;
	private float birdSpeed = 2f;

	private Vector3 targetVector;

	private void Start()
	{
		_birdTransform = bird.transform;
		_birdAnimator = bird.GetComponent<Animator>();
		_birdSpriteRenderer = bird.GetComponent<SpriteRenderer>();
		_birdAnimator.SetBool(IsWalk, false);

		targetVector = maincamera.transform.position;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.A))
			MoveLeft();
		
		if (Input.GetKey(KeyCode.D))
			MoveRight();

		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
			_birdAnimator.SetBool(IsWalk, false);
	}

	private void FixedUpdate()
	{
		maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, targetVector, Time.deltaTime);
		background.transform.position = Vector3.Lerp(background.transform.position, targetVector + new Vector3(3, 0, 10), Time.deltaTime);
		moon.transform.position = Vector3.Lerp(moon.transform.position, targetVector * 0.9f + new Vector3(3, 0.6f, 10), Time.deltaTime);
		
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
		
		targetVector += Vector3.right * speed;
	}

	public void MoveLeft()
	{
		_birdTransform.position += new Vector3(-birdSpeed * Time.deltaTime, 0, 0);
		//_birdRigidbody2D.AddForce(new Vector3(-birdSpeed, 0, 0));
		_birdAnimator.SetBool(IsWalk, true);
		_birdSpriteRenderer.flipX = true;
	}

	public void MoveRight()
	{
		if (_birdTransform.position.x - 1.5f > targetVector.x)
		{
			targetVector = new Vector3(_birdTransform.position.x - 1.5f, targetVector.y, -10);
		}

		_birdTransform.position += new Vector3(birdSpeed * Time.deltaTime, 0, 0);
		//_birdRigidbody2D.AddForce(new Vector3(birdSpeed, 0, 0));
		_birdAnimator.SetBool(IsWalk, true);
		_birdSpriteRenderer.flipX = false;
	}
}
