using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
	public CameraMovement _cameraMovement;
	public HorizontalButton horizontalButton;

	// bird property
	private static readonly int IsWalk = Animator.StringToHash("is_walk");
	private Transform _birdTransform;
	private BirdCustomAnimation _birdAnimator;
	private Rigidbody2D _birdRigidbody2D;
	private Vector3 localScale;
	private float birdSpeed = 2f;
	private bool can_jump = true;

	private void Start()
	{
		localScale = gameObject.transform.localScale;
		_birdTransform = gameObject.transform;
		_birdAnimator = GetComponent<BirdCustomAnimation>();
		_birdRigidbody2D = GetComponent<Rigidbody2D>();
		_birdAnimator.isWalking = false;
	}

	private void Update()
	{
		birdSpeed = 0;	// 임시로 해놓음 (키보드)
		birdSpeed += Input.GetAxisRaw("Horizontal") * 2;
		birdSpeed += horizontalButton.GETDir() * 2;
		
		if (birdSpeed == 0)
			_birdAnimator.isWalking = false;
		else
		{
			_birdTransform.position += new Vector3(birdSpeed * Time.deltaTime, 0, 0);
			//_birdRigidbody2D.AddForce(new Vector3(birdSpeed, 0, 0));
			_birdAnimator.isWalking = true;

			if (birdSpeed > 0)
			{
				gameObject.transform.localScale = localScale;
				MoveRight();
			}
			else
				gameObject.transform.localScale = new Vector3(-localScale.x, localScale.y, 1);
		}
	}

	private void MoveRight()
	{
		// 카메라 뒤로 물러남
		if (_birdTransform.position.x - 2 > _cameraMovement.cameraTargetVector.x)
		{
			//_runningScene.cameraTargetVector = new Vector3(_birdTransform.position.x - 1.5f, _runningScene.cameraTargetVector.y, -10);
			_cameraMovement.cameraTargetVector = new Vector3(_birdTransform.position.x + 1f, _cameraMovement.cameraTargetVector.y, -10);
		}
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
