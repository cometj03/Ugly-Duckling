using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
	public HorizontalButton horizontalButton;

	private GameManager _gameManager;
	
	// bird property
	private Transform _birdTransform;
	private BirdCustomAnimation _birdAnimator;
	private Rigidbody2D _birdRigidbody2D;
	private Vector3 localScale;
	private float birdSpeed;
	private bool can_jump = true;

	private void Start()
	{
		_gameManager = FindObjectOfType<GameManager>();

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
		birdSpeed += horizontalButton.GETDir() * 1.7f;
		
		if (birdSpeed == 0)
			_birdAnimator.isWalking = false;
		else if (_gameManager.currentState == GameManager.GameState.CONTINUE)
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
			_birdRigidbody2D.AddForce(Vector2.up * 250);
			can_jump = false;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		can_jump = true;
	}
}
