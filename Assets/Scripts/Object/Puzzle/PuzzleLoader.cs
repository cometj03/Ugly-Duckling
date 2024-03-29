﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
//using TMPro.EditorUtilities;

public class PuzzleLoader : MonoBehaviour
{
	public string[] puzzleNums;
	
	public GameObject puzzle;
	public GameObject tile;
	public GameObject block;
	public GameObject outlineTile;
	public GameObject outline;

	Puzzle writingPuzzle;
	Outline writingOutline;
	Block writingBlock;

	int blockColorIndex = 0;
	List<Color> blockColors = new List<Color>(){
		new Color(0.9960784f, 0.9607843f, 0.8313726f),
		new Color(1, 0.8392157f, 0.6666667f),
		new Color(0.9372549f, 0.7294118f, 0.8392157f),
		new Color(0.854902f, 0.854902f, 0.9882353f)
	};

	public Puzzle FileToPuzzle(string src)
	{
		writingPuzzle = Instantiate(puzzle).GetComponent<Puzzle>();

		var file = File.OpenRead("Assets/Puzzles/" + src);
		StreamReader sr = new StreamReader(file);

		var json = JSON.Parse(sr.ReadToEnd());

		sr.Close();
		file.Close();

		writingOutline = Instantiate(outline).GetComponent<Outline>();

		writingOutline.transform.SetParent(writingPuzzle.transform);

		foreach (var iter in json["outline"])
		{
			OutlineTile tmp = Instantiate(outlineTile).GetComponent<OutlineTile>();

			tmp.transform.localPosition = new Vector2(iter.Value["x"], iter.Value["y"]);
			tmp.position = tmp.transform.localPosition;
			tmp.transform.SetParent(writingOutline.transform);

			writingOutline.Insert(tmp);
		}

		writingOutline.UpdateLInk();
		writingOutline.UpdateShape();

		writingPuzzle.outline = writingOutline;

		foreach (var blocks in json["blocks"])
		{
			writingBlock = Instantiate(block).GetComponent<Block>();

			Color blockColor = blockColors[blockColorIndex++];
			if (blockColorIndex > blockColors.Count - 1)
			{
				blockColorIndex = 0;
			}
			writingBlock.transform.SetParent(writingPuzzle.transform);

			foreach (var tiles in blocks.Value)
			{
				Tile tmp = Instantiate(tile).GetComponent<Tile>();

				tmp.transform.localPosition = new Vector2(tiles.Value["x"], tiles.Value["y"]);
				tmp.position = tmp.transform.localPosition;
				tmp.GetComponent<SpriteRenderer>().color = blockColor;
				tmp.transform.SetParent(writingBlock.transform);

				writingBlock.Insert(tmp);
			}

			writingBlock.UpdateLink();
			writingBlock.UpdateShape();

			writingPuzzle.blocks.Add(writingBlock);
		}

		return writingPuzzle;
	}

	private void Awake()
	{
		//foreach (var t in puzzleNums)
		//	FileToPuzzle("newPuzzle" + t);
	}
}
