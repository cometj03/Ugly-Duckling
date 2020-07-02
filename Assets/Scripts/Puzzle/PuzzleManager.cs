using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleManager : MonoBehaviour
{
	public Camera maincamera;

	GameObject touching = null;

	Vector3 distance;
	Vector3 late_position;
	Vector3 touch_vec;
	RaycastHit2D hit;

	bool touch_down = false;

	private void Awake()
	{
		late_position = transform.position;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
		{
			touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
			if(Input.touchCount > 0)
				touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.transform.position.y));
			hit = Physics2D.Raycast(touch_vec, maincamera.transform.forward);

			if (hit && hit.collider.tag == "PuzzleBlock")
			{
				distance = hit.collider.gameObject.transform.position - touch_vec;
				touching = hit.collider.gameObject;
			}

			touch_down = true;
		}
		else if (Input.GetMouseButton(0) || (touch_down && Input.touchCount > 0))
		{
			if(touching != null)
			{
				late_position = touching.transform.position;
				touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
				if (Input.touchCount > 0)
					touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.transform.position.y));
				touching.transform.position = touch_vec + distance;
			}
		}
		else if (Input.GetMouseButtonUp(0) || Input.touchCount == 0)
		{
			distance = Vector3.zero;
			touch_vec = Vector3.zero;
			touching = null;
			touch_down = false;
		}
	}
}
