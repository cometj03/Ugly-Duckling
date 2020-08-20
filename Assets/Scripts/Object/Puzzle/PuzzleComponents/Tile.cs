using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public enum TILE_TYPE { OUTLINE, TILE };

	public TILE_TYPE tile_type { get; set; }

	Dictionary<string, Tile> links = new Dictionary<string, Tile>()
	{
		{"right",null },
		{"down",null },
		{"left",null },
		{"up",null },
	};

	public int x { get; set; } = 0;
	public int y { get; set; } = 0;

	public Tile getLink(string key)
	{
		return links[key];
	}

	public void setLink(string key, Tile tile)
	{
		links[key] = tile;
	}

	public void updateShape()
	{
		string src = "";

		if (tile_type == TILE_TYPE.TILE)
		{
			src = "Tiles/tile";
		}
		else if(tile_type == TILE_TYPE.OUTLINE)
		{
			src = "OutLines/outline";
		}

		foreach(var pair in links)
		{
			if(pair.Value != null)
			{
				src += "_" + pair.Key;
			}
		}

		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(src);
	}
}
