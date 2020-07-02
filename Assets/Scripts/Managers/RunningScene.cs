using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningScene : MonoBehaviour
{
	public GameObject bird;
	public GameObject floor;
	public GameObject moon;
	public GameObject background;
	public GameObject mountin;
	public GameObject mountincloud;
	public Camera maincamera;

	public float speed = 0.1f;

	private void Awake()
	{
		bird.GetComponent<Animator>().SetBool("is_walk", true);
	}

	private void FixedUpdate()
	{
		if (maincamera.transform.position.x - 4.8f >= floor.transform.position.x)
		{
			floor.transform.position += new Vector3(9.6f, 0, 0);
		}

		bird.transform.position += Vector3.right * speed * (maincamera.transform.position.x - 4 > bird.transform.position.x ? 2 : 1);
		moon.transform.position += Vector3.right * speed * 0.9f;
		background.transform.position += Vector3.right * speed * 0.95f;
		mountin.transform.position += Vector3.right * speed * 0.7f;
		mountincloud.transform.position += Vector3.right * speed * 0.6f;
		maincamera.transform.position += Vector3.right * speed;
	}

	public void Jump()
	{
		bird.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250);
	}
}
