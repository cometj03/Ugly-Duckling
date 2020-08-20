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

	GameObject writingpuzzle;
	GameObject writingblock;

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

	private void Awake()
	{
		writingpuzzle = Instantiate(puzzle);
	}

	private void Update()
	{
		TilePreview();

		if (type == TILE_TYPE.BLOCK)
		{
			WriteBlock();
		}

		perPreviewPos = preview.transform.position;
	}
}
