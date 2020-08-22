using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.Mathematics;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
	public enum TILE_TYPE { OUTLINE, BLOCK, AIR };

	public TILE_TYPE type;

	public GameObject preview;
	public GameObject puzzle;
	public GameObject tile;
	public GameObject block;
	public GameObject outlineTile;
	public GameObject outline;

	GameObject writingpuzzle;
	GameObject writingblock;
	GameObject writingoutline;

	public List<List<Tile>> grid;

	Vector2 perPreviewPos;

	public void TilePreview()
	{
		preview.transform.position = (Vector2)math.round((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	public void WriteBlock()
	{
		if (Input.GetMouseButtonDown(0))
		{
			writingblock = Instantiate(block);
			writingblock.transform.SetParent(writingpuzzle.transform);
			writingpuzzle.GetComponent<Puzzle>().blocks.Add(writingblock.GetComponent<Block>());

			GameObject tmp = Instantiate(tile);

			tmp.transform.SetParent(writingblock.transform);
			tmp.transform.position = preview.transform.position;

			writingblock.GetComponent<Block>().Insert(tmp.GetComponent<Tile>());
		}
		else if (Input.GetMouseButton(0))
		{
			if (perPreviewPos != (Vector2)preview.transform.position)
			{
				GameObject tmp = Instantiate(tile);

				tmp.transform.SetParent(writingblock.transform);
				tmp.transform.position = preview.transform.position;

				writingblock.GetComponent<Block>().Insert(tmp.GetComponent<Tile>());
			}
		}
	}

	public void WriteOutline()
	{
		if (Input.GetMouseButtonDown(0))
		{
			writingoutline.GetComponent<Outline>().Clear();

			GameObject tmp = Instantiate(outlineTile);

			tmp.transform.SetParent(writingoutline.transform);
			tmp.transform.position = preview.transform.position;

			writingoutline.GetComponent<Outline>().Insert(tmp.GetComponent<OutlineTile>());
		}
		else if (Input.GetMouseButton(0))
		{
			if (perPreviewPos != (Vector2)preview.transform.position)
			{
				GameObject tmp = Instantiate(outlineTile);

				tmp.transform.SetParent(writingoutline.transform);
				tmp.transform.position = preview.transform.position;

				writingoutline.GetComponent<Outline>().Insert(tmp.GetComponent<OutlineTile>());
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			writingoutline.GetComponent<Outline>().UpdateLInk();
			writingoutline.GetComponent<Outline>().UpdateShape();
		}
	}

	public void ChangeModeToBlock()
	{
		type = TILE_TYPE.BLOCK;
	}

	public void ChangeModeToOutline()
	{
		type = TILE_TYPE.OUTLINE;
	}

	public void SaveToFile()
	{
		writingpuzzle.GetComponent<Puzzle>().SaveToFile();
	}

	private void Awake()
	{
		writingpuzzle = Instantiate(puzzle);
		writingoutline = Instantiate(outline);
		writingoutline.transform.SetParent(writingpuzzle.transform);
		writingpuzzle.GetComponent<Puzzle>().outline = writingoutline.GetComponent<Outline>();
	}

	private void Update()
	{
		TilePreview();

		if (type == TILE_TYPE.BLOCK)
		{
			WriteBlock();
		}
		else if (type == TILE_TYPE.OUTLINE)
		{
			WriteOutline();
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			ChangeModeToBlock();
		}
		else if (Input.GetKeyDown(KeyCode.O))
		{
			ChangeModeToOutline();
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			SaveToFile();
		}

		perPreviewPos = preview.transform.position;
	}
}
