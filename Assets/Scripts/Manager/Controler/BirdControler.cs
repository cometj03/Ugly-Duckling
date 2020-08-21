using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControler : MonoBehaviour
{
	public GameObject manager;
	
	private RunningScene _runningScene;
	
	// bird property
	private static readonly int IsWalk = Animator.StringToHash("is_walk");
	private Transform _birdTransform;
	private Animator _birdAnimator;
	private SpriteRenderer _birdSpriteRenderer;
	private Rigidbody2D _birdRigidbody2D;
	private float birdSpeed = 2f;
	private bool can_jump = true;

	private void Start()
	{
		_runningScene = manager.GetComponent<RunningScene>();
		
		_birdTransform = gameObject.transform;
		_birdAnimator = GetComponent<Animator>();
		_birdSpriteRenderer = GetComponent<SpriteRenderer>();
		_birdRigidbody2D = GetComponent<Rigidbody2D>();
		_birdAnimator.SetBool(IsWalk, false);
	}

	private void Update()
	{
		birdSpeed = Input.GetAxisRaw("Horizontal") * 2;
		
		if (birdSpeed > 0)
			MoveRight();
		else if (birdSpeed < 0)
			MoveLeft();
		else
			_birdAnimator.SetBool(IsWalk, false);
	}

	public void MoveRight()
	{
		// 카메라 뒤로 물러남
		if (_birdTransform.position.x - 1.5f > _runningScene.cameraTargetVector.x)
		{
			_runningScene.cameraTargetVector = new Vector3(_birdTransform.position.x - 1.5f, _runningScene.cameraTargetVector.y, -10);
		}

		_birdTransform.position += new Vector3(birdSpeed * Time.deltaTime, 0, 0);
		//_birdRigidbody2D.AddForce(new Vector3(birdSpeed, 0, 0));
		_birdAnimator.SetBool(IsWalk, true);
		_birdSpriteRenderer.flipX = false;
	}

	public void MoveLeft()
	{
		_birdTransform.position += new Vector3(birdSpeed * Time.deltaTime, 0, 0);
		//_birdRigidbody2D.AddForce(new Vector3(-birdSpeed, 0, 0));
		_birdAnimator.SetBool(IsWalk, true);
		_birdSpriteRenderer.flipX = true;
	}

	public void BirdJump()
	{
		if (can_jump)
		{
			_birdRigidbody2D.AddForce(Vector2.up * 250);
			can_jump = false;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		can_jump = true;
	}
}
