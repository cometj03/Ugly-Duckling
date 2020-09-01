using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
//using TMPro.EditorUtilities;

public class PuzzleLoader : MonoBehaviour
{
	public GameObject puzzle;
	public GameObject tile;
	public GameObject block;
	public GameObject outlineTile;
	public GameObject outline;

	Puzzle writingPuzzle;
	Outline writingOutline;
	Block writingBlock;

	public Puzzle FileToPuzzle(string src)
	{
		writingPuzzle = Instantiate(puzzle).GetComponent<Puzzle>();

		var file = File.OpenRead(src);
		StreamReader sr = new StreamReader(file);

		var json = JSON.Parse(sr.ReadToEnd());

		sr.Close();
		file.Close();

		writingOutline = Instantiate(outline).GetComponent<Outline>();

		writingOutline.transform.SetParent(writingPuzzle.transform);

		foreach(var iter in json["outline"])
		{
			OutlineTile tmp = Instantiate(outlineTile).GetComponent<OutlineTile>();

			tmp.transform.position = new Vector2(iter.Value["x"], iter.Value["y"]);
			tmp.transform.SetParent(writingOutline.transform);
			writingOutline.Insert(tmp);
		}

		writingOutline.UpdateLInk();
		writingOutline.UpdateShape();

		foreach(var blocks in json["blocks"])
		{
			writingBlock = Instantiate(block).GetComponent<Block>();

			writingBlock.transform.SetParent(writingPuzzle.transform);

			foreach(var tiles in blocks.Value)
			{
				Tile tmp = Instantiate(tile).GetComponent<Tile>();

				tmp.transform.position = new Vector2(tiles.Value["x"], tiles.Value["y"]);
				tmp.transform.SetParent(writingBlock.transform);

				writingBlock.Insert(tmp);
			}

			writingBlock.UpdateLink();
			writingBlock.UpdateShape();
		}

		return writingPuzzle;
	}

	private void Awake()
	{
		FileToPuzzle("newPuzzle");
	}
}
