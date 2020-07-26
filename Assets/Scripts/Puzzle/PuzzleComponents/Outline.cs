using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
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
		Vector3 tile_vec = Vector3.zero;
		foreach (var iter in tiles)
		{
			if (iter == tiles[0])
			{
				tile_vec = iter.transform.position;
				continue;
			}
			else if (iter == tiles[tiles.Count - 1])
			{
				tile_vec -= tiles[0].transform.position;
			}
			else
			{
				tile_vec -= iter.transform.position;
			}

			if (tile_vec.x == -1 && tile_vec.y == 0)
			{
				iter.setLink("right", tiles[tiles.IndexOf(iter) - 1]);
				tiles[tiles.IndexOf(iter) - 1].setLink("left", iter);

				Debug.Log(tiles[tiles.IndexOf(iter) - 1].transform.position + " " + iter.transform.position);
			}
			else if (tile_vec.x == 1 && tile_vec.y == 0)
			{
				iter.setLink("left", tiles[tiles.IndexOf(iter) - 1]);
				tiles[tiles.IndexOf(iter) - 1].setLink("right", iter);

				Debug.Log(tiles[tiles.IndexOf(iter) - 1].transform.position + " " + iter.transform.position);
			}
			else if (tile_vec.x == 0 && tile_vec.y == -1)
			{
				iter.setLink("up", tiles[tiles.IndexOf(iter) - 1]);
				tiles[tiles.IndexOf(iter) - 1].setLink("down", iter);

				Debug.Log(tiles[tiles.IndexOf(iter) - 1].transform.position + " " + iter.transform.position);
			}
			else if (tile_vec.x == 0 && tile_vec.y == 1)
			{
				iter.setLink("down", tiles[tiles.IndexOf(iter) - 1]);
				tiles[tiles.IndexOf(iter) - 1].setLink("up", iter);

				Debug.Log(tiles[tiles.IndexOf(iter) - 1].transform.position + " " + iter.transform.position);
			}

			tile_vec = iter.transform.position;
			tiles[tiles.IndexOf(iter) - 1].updateShape();
		}
	}
}
