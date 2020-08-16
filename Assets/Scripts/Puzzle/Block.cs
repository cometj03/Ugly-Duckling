using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	enum BLOCK_TYPE { NORMAL};

	BLOCK_TYPE type = BLOCK_TYPE.NORMAL;

	List<Tile> tiles;

	public void Insert(Tile tile)
	{
		tiles.Add(tile);
	}

	public void UpdateShape()
	{
		foreach(var tile in tiles)
		{
			
		}
	}
}
