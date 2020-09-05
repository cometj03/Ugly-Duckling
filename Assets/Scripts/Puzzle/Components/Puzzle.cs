using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Puzzle : MonoBehaviour
{
	public Outline outline;
	public List<Block> blocks = new List<Block>();

	public void SaveToFile(string fileName)
	{
		FileStream file = File.Create(fileName);

		Hashtable h_puzzle = new Hashtable();
		List<Hashtable> h_outline = new List<Hashtable>();
		List<List<Hashtable>> h_blocks = new List<List<Hashtable>>();

		foreach(var outlinetile in outline.GetTiles())
		{
			Hashtable h_outlineTile = new Hashtable();

			h_outlineTile.Add("x", outlinetile.transform.position.x);
			h_outlineTile.Add("y", outlinetile.transform.position.y);

			h_outline.Add(h_outlineTile);
		}

		foreach(var block in blocks)
		{
			List<Hashtable> h_block = new List<Hashtable>();

			foreach(var tile in block.GetTiles())
			{
				Hashtable h_tile = new Hashtable();
				h_tile.Add("x", tile.transform.position.x);
				h_tile.Add("y", tile.transform.position.y);

				h_block.Add(h_tile);
			}
			h_blocks.Add(h_block);
		}

		h_puzzle.Add("outline", h_outline);
		h_puzzle.Add("blocks", h_blocks);

		string json = JsonConvert.SerializeObject(h_puzzle);

		Debug.Log(json);

		StreamWriter sw = new StreamWriter(file);

		sw.Write(json);

		sw.Close();
		file.Close();
	}
}
