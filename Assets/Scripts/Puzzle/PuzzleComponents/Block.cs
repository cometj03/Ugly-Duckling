using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	List<Tile> tiles = new List<Tile>();

	public void pushTile() //게임오브젝트에서 타일을 불러와 업데이트
	{
		Tile tile = new Tile(x, y);

		tiles.Add(tile);

		foreach(var iter in tiles)
		{
			if(iter.getX() + 1 == x && iter.getY() == y)
			{
				tile.setLink("right", iter);
			}
			else if (iter.getX() - 1== x && iter.getY() == y)
			{
				tile.setLink("left", iter);
			}
			else if (iter.getX() == x && iter.getY() + 1== y)
			{
				tile.setLink("up", iter);
			}
			else if (iter.getX() == x && iter.getY() - 1== y)
			{
				tile.setLink("down", iter);
			}
		}

		tile.updateShape();
	}
}