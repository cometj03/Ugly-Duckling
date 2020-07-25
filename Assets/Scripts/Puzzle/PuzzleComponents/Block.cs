using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	List<Tile> tiles = new List<Tile>();

	public void pushTile(Tile tile) //게임오브젝트에서 타일을 불러와 업데이트
	{
		tiles.Add(tile);

		foreach (var iter in tiles)
		{
			if (iter.x + 1 == tile.x && iter.y == tile.y)
			{
				iter.setLink("right", tile);
				tile.setLink("left", iter);
			}
			else if (iter.x - 1 == tile.x && iter.y == tile.y)
			{
				iter.setLink("left", tile);
				tile.setLink("right", iter);
			}
			else if (iter.x == tile.x && iter.y + 1 == tile.y)
			{
				iter.setLink("up", tile);
				tile.setLink("down", iter);
			}
			else if (iter.x == tile.x && iter.y - 1 == tile.y)
			{
				iter.setLink("down", tile);
				tile.setLink("up", iter);
			}

			iter.updateShape();
		}

		tile.updateShape();
	}
}