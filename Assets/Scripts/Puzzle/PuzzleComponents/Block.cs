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
			if (iter.getX() + 1 == tile.getX() && iter.getY() == tile.getY())
			{
				iter.setLink("right", tile);
				tile.setLink("left", iter);
			}
			else if (iter.getX() - 1 == tile.getX() && iter.getY() == tile.getY())
			{
				iter.setLink("left", tile);
				tile.setLink("right", iter);
			}
			else if (iter.getX() == tile.getX() && iter.getY() + 1 == tile.getY())
			{
				iter.setLink("up", tile);
				tile.setLink("down", iter);
			}
			else if (iter.getX() == tile.getX() && iter.getY() - 1 == tile.getY())
			{
				iter.setLink("down", tile);
				tile.setLink("up", iter);
			}

			iter.updateShape();
		}

		tile.updateShape();
	}
}