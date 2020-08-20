using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public List<bool> isConnect = new List<bool>(4) { false, false, false, false };

	public int x;
	public int y;

	public void UpdateShapde()
	{
		for (int i = 0; i < 4	; i++)
		{
			if (isConnect[i])
			{
				transform.GetChild(i).gameObject.SetActive(isConnect[i]);
			}
		}
	}
}