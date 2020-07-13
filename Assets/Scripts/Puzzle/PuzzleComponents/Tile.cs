using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	Dictionary<string, Tile> links = new Dictionary<string, Tile>()
	{
		{"right",null },
		{"down",null },
		{"left",null },
		{"up",null },
	};

	int x = 0;
	int y = 0;

	public Tile(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public Tile getLink(string key)
	{
		return links[key];
	}

	public void setLink(string key, Tile tile)
	{
		links[key] = tile;
	}

	public int getX()
	{
		return x;
	}

	public int getY()
	{
		return y;
	}

	public void setX(int x)
	{
		this.x = x;
	}

	public void setY(int y)
	{
		this.y = y;
	}

	public void updateShape()
	{
		string src = "Sprites/Tiles/Tiles/tile";

		foreach(var pair in links)
		{
			if(pair.Value != null)
			{
				src += pair.Key;
			}
		}

		Debug.Log(src);
	}
}
