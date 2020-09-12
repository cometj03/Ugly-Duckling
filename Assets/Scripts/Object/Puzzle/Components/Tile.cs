using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public List<bool> isConnect;

	public Vector2 position;

	private void Awake()
	{
		isConnect = new List<bool> { false, false, false, false };

		position = transform.localPosition;
	}

	public void UpdateShape()
	{
		for (int i = 0; i < 4; i++)
		{
			transform.GetChild(i).gameObject.SetActive(!isConnect[i]);
		}
	}
}