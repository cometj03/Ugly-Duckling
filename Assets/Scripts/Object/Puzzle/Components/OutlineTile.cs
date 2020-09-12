using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class OutlineTile : MonoBehaviour
{
	public List<string> isConnected = new List<string>();

	public Vector2 position;

	private void Awake()
	{
		position = transform.localPosition;
	}

	public void UpdateShape()
	{
		string src = "OutLines/outline";

		foreach(string connect in isConnected)
		{
			src += "_" + connect;
		}

		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(src);
	}
}
