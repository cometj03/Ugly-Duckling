using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	enum BLOCK_TYPE { NORMAL };

	//BLOCK_TYPE type = BLOCK_TYPE.NORMAL;

	public List<Tile> tiles = new List<Tile>();

	public void Insert(Tile tile)
	{
		tiles.Add(tile);
		UpdateLink();
		UpdateShape();
	}

	public void UpdateShape()	
	{
		foreach (var tile in tiles)
		{
			for (int i = 0; i < 4; i++)
			{
				tile.transform.GetChild(i).gameObject.SetActive(!tile.isConnect[i]);
			}
		}
	}

	public void UpdateLink()
	{
		foreach (var tile1 in tiles)
		{
			foreach (var tile2 in tiles)
			{
				if (tile1.transform.position == tile2.transform.position + new Vector3(1, 0, 0))
				{
					tile1.GetComponent<Tile>().isConnect[1] = true;
					tile2.GetComponent<Tile>().isConnect[0] = true;
				}
				else if (tile1.transform.position == tile2.transform.position + new Vector3(-1, 0, 0))
				{
					tile1.GetComponent<Tile>().isConnect[0] = true;
					tile2.GetComponent<Tile>().isConnect[1] = true;
				}
				else if (tile1.transform.position == tile2.transform.position + new Vector3(0, 1, 0))
				{
					tile1.GetComponent<Tile>().isConnect[3] = true;
					tile2.GetComponent<Tile>().isConnect[2] = true;
				}
				else if (tile1.transform.position == tile2.transform.position + new Vector3(0, -1, 0))
				{
					tile1.GetComponent<Tile>().isConnect[2] = true;
					tile2.GetComponent<Tile>().isConnect[3] = true;
				}
			}
		}
	}
}
