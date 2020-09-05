using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public List<bool> isConnect;

	private void OnMouseDown()
	{
		GameObject parent = transform.parent.gameObject;

		parent.transform.parent.GetComponent<Puzzle>().blocks.Remove(parent.GetComponent<Block>());
		Destroy(parent);
	}

	private void Awake()
	{
		isConnect = new List<bool> { false, false, false, false };
	}

	public void UpdateShape()
	{
		for (int i = 0; i < 4; i++)
		{
			transform.GetChild(i).gameObject.SetActive(!isConnect[i]);
		}
	}
}