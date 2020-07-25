using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
	enum DIRECTION { RIGHT, LEFT, UP, DOWN };

	public List<Tile> tiles = new List<Tile>();

	public void Clear()
	{
		foreach (var iter in tiles)
		{
			Destroy(iter.gameObject);
		}

		tiles.Clear();
	}

	public void UpdateShape()
	{
		foreach (var iter in tiles)
		{
			
		}
	}
}
