using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
	public Camera maincamera;

	public GameObject mainpuzzle;

	GameObject touching = null;

	Vector3 distance;
	Vector3 touch_vec;
	RaycastHit2D hit;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
			hit = Physics2D.Raycast(touch_vec, maincamera.transform.forward);

			if (hit && hit.collider.tag == "PuzzleBlock")
			{
				distance = GameObject.Find(hit.collider.name).transform.position - touch_vec;
				touching = GameObject.Find(hit.collider.name);
			}
		}
		else if (Input.GetMouseButton(0))
		{
			if(touching != null)
			{
				touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
				touching.transform.position = touch_vec + distance;
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			distance = Vector3.zero;
			touch_vec = Vector3.zero;
			touching = null;
		}
	}
}
