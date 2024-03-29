﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
	public HorizontalButton horizontalButton;
	
	// bird property
	private Transform _birdTransform;
	private BirdCustomAnimation _birdAnimator;
	private Rigidbody2D _birdRigidbody2D;
	private Vector3 localScale;
	private float birdSpeed;
	private bool can_jump;
	
	Vector3 spawnPosition = new Vector3(-3, -0.2f, 0);

	private void Start()
	{
		// TODO:
		PlayerData.Instance.currentState = GameState.CONTINUE;
		
		localScale = gameObject.transform.localScale;
		_birdTransform = gameObject.transform;
		_birdAnimator = GetComponent<BirdCustomAnimation>();
		_birdRigidbody2D = GetComponent<Rigidbody2D>();
		_birdAnimator.isWalking = false;
		can_jump = true;

		_birdTransform.position = spawnPosition;
	}

	private void FixedUpdate()
	{
		birdSpeed = 0;	// 임시로 해놓음 (키보드)
		birdSpeed += Input.GetAxisRaw("Horizontal") * 2;
		birdSpeed += horizontalButton.GETDir() * 1.7f;
		
		if (birdSpeed == 0)
			_birdAnimator.isWalking = false;
		else if (PlayerData.Instance.currentState == GameState.CONTINUE)
		{
			_birdTransform.position += new Vector3(birdSpeed * Time.deltaTime, 0, 0);
			_birdAnimator.isWalking = true;

			if (birdSpeed >= 0)
				gameObject.transform.localScale = localScale;
			else
				gameObject.transform.localScale = new Vector3(-localScale.x, localScale.y, 1);
		}
	}

	public void BirdJump()
	{
		if (can_jump)
		{
			SoundManager.instance.PlaySFX(eSFX.Jump);
			_birdRigidbody2D.AddForce(Vector2.up * 270);
			can_jump = false;
		}
	}

	public void BirdPush(float dx, float dy)
    {
		_birdRigidbody2D.AddForce(new Vector2(dx, dy));
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		can_jump = true;
	}
}
