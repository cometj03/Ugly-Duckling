using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaker : MonoBehaviour
{
	Vector3 per_touch_vec;
	Vector3 touch_vec;

	public GameObject tile;

	enum PUZZLE_TYPE { OUTLINE, BLOCK };

	private void Awake()
	{
		per_touch_vec = Vector3.zero;
		touch_vec = Vector3.zero;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
			touch_vec = Vector3Int.RoundToInt(touch_vec);
			touch_vec.z = 0;
		}
		else if (Input.GetMouseButton(0))
		{
			per_touch_vec = touch_vec;

			touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
			touch_vec = Vector3Int.RoundToInt(touch_vec);
			touch_vec.z = 0;

			if (touch_vec != per_touch_vec)
			{
				GameObject tmp = Instantiate(tile);

				tmp.transform.position = touch_vec;
			}
		}
	}
}
