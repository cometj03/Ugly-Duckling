using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    List<OutlineTile> tiles = new List<OutlineTile>();

	public List<OutlineTile> GetTiles()
	{
		return tiles;
	}

	public void Clear()
	{
		foreach(var tile in tiles)
		{
			Destroy(tile.gameObject);
		}

		tiles.Clear();
	}

    public void Insert(OutlineTile tile)
	{
		tiles.Add(tile);
	}

	public void UpdateShape()
	{
		foreach(var tile in tiles)
		{
			tile.UpdateShape();
		}
	}

	public void UpdateLInk()
	{
		OutlineTile tile1 = tiles[0];
		foreach(var tile2 in tiles)
		{
			if (tile1.transform.position == tile2.transform.position + new Vector3(1, 0, 0))
			{
				tile1.GetComponent<OutlineTile>().isConnected.Add("left");
				tile2.GetComponent<OutlineTile>().isConnected.Add("right");
			}
			else if (tile1.transform.position == tile2.transform.position + new Vector3(-1, 0, 0))
			{
				tile1.GetComponent<OutlineTile>().isConnected.Add("right");
				tile2.GetComponent<OutlineTile>().isConnected.Add("left");
			}
			else if (tile1.transform.position == tile2.transform.position + new Vector3(0, 1, 0))
			{
				tile1.GetComponent<OutlineTile>().isConnected.Add("down");
				tile2.GetComponent<OutlineTile>().isConnected.Add("up");
			}
			else if (tile1.transform.position == tile2.transform.position + new Vector3(0, -1, 0))
			{
				tile1.GetComponent<OutlineTile>().isConnected.Add("up");
				tile2.GetComponent<OutlineTile>().isConnected.Add("down");
			}
			tile1 = tile2;
		}

		if (tiles[0].transform.position == tiles[tiles.Count - 1].transform.position + new Vector3(1, 0, 0))
		{
			tiles[0].GetComponent<OutlineTile>().isConnected.Add("left");
			tiles[tiles.Count - 1].GetComponent<OutlineTile>().isConnected.Add("right");
		}
		else if (tiles[0].transform.position == tiles[tiles.Count - 1].transform.position + new Vector3(-1, 0, 0))
		{
			tiles[0].GetComponent<OutlineTile>().isConnected.Add("right");
			tiles[tiles.Count - 1].GetComponent<OutlineTile>().isConnected.Add("left");
		}
		else if (tiles[0].transform.position == tiles[tiles.Count - 1].transform.position + new Vector3(0, 1, 0))
		{
			tiles[0].GetComponent<OutlineTile>().isConnected.Add("down");
			tiles[tiles.Count - 1].GetComponent<OutlineTile>().isConnected.Add("up");
		}
		else if (tiles[0].transform.position == tiles[tiles.Count - 1].transform.position + new Vector3(0, -1, 0))
		{
			tiles[0].GetComponent<OutlineTile>().isConnected.Add("up");
			tiles[tiles.Count - 1].GetComponent<OutlineTile>().isConnected.Add("down");
		}
	}
}
